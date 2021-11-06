package clientserver

import (
	"bufio"
	"fmt"
	"io"
	"net"
	"os"
	"strings"
)

func ViewError(err error) {
	fmt.Printf("[ERROR] - %s\n", err)
}

func CloseConn(connection net.Conn) {
	connection.Close()
}

func ScanString(text string) (string, error) {
	reader := bufio.NewReader(os.Stdin)

	fmt.Print(text)
	message, err := reader.ReadString('\n')
	if err != nil {
		return "", err
	}

	return message, nil
}

type DataBaseUsers map[*net.Conn]string

func ProcessUser(connection *net.Conn, users *DataBaseUsers) {
	defer delete(*users, connection)
	defer fmt.Printf("user(%s) disconnected\n", (*connection).RemoteAddr().String())
	defer CloseConn(*connection)

	(*users)[connection] = (*connection).RemoteAddr().String()

	var str strings.Builder
	for {
		data := make([]byte, 32)

		n, err := (*connection).Read(data)
		if err != nil {
			if err == io.EOF {
				break
			} else {
				ViewError(err)
			}
		}
		str.Write(data)

		if n == 0 {
			break
		}

		if n < 32 {
			fmt.Printf("client(%s): %s", (*connection).RemoteAddr().String(), str.String())

			for host := range *users {
				if host == connection {
					continue
				}

				(*host).Write([]byte(fmt.Sprintf("client(%s): %s", (*connection).RemoteAddr().String(), str.String())))
			}

			str.Reset()
		}

	}
}

func Server(host, port string) {
	var users DataBaseUsers = make(DataBaseUsers)
	fmt.Printf("(%s)\n", string(host+":"+port))
	listener, err := net.Listen("tcp", host+":"+port)

	if err != nil {
		ViewError(err)
		os.Exit(1)
	}
	defer listener.Close()
	fmt.Println("Server listening...")

	for {
		connection, err := listener.Accept()
		if err != nil {
			ViewError(err)
			continue
		}

		go ProcessUser(&connection, &users)
		fmt.Printf("user(%s) connected\n", connection.RemoteAddr().String())
		for host := range users {
			if *host == connection {
				continue
			}

			(*host).Write([]byte(fmt.Sprintf("user(%s) connected\n", connection.RemoteAddr().String())))
		}
	}
}

func ReadMessages(connection *net.Conn) {
	for {
		io.Copy(os.Stdout, *connection)
	}
}

func Client(host, port string) {
	connection, err := net.Dial("tcp", host+":"+port)
	if err != nil {
		ViewError(err)
		os.Exit(3)
	}
	defer CloseConn(connection)

	go ReadMessages(&connection)

	var message string
	for {
		message, err = ScanString("Enter message: ")
		if err != nil {
			ViewError(err)
			continue
		}
		if strings.HasPrefix(message, "!close") {
			CloseConn(connection)
			break
		}
		connection.Write([]byte(message))
	}

}

func Viewer(host, port string) {
	connection, err := net.Dial("tcp", host+":"+port)
	if err != nil {
		ViewError(err)
		os.Exit(3)
	}
	defer CloseConn(connection)

	ReadMessages(&connection)
}
