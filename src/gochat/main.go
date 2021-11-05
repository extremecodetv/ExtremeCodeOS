package main

import (
	"fmt"
	"os"
	"strings"

	"./clientserver"
)

func main() {
repeat:

	select_mode, err := clientserver.ScanString("Select(server, client, viewer): ")
	var ip, port string
	if err != nil {
		clientserver.ViewError(err)
		os.Exit(4)
	}

	if strings.HasPrefix(select_mode, "server") {
		fmt.Print("Enter ip: ")
		fmt.Scan(&ip)

		fmt.Print("Enter port: ")
		fmt.Scan(&port)

		clientserver.Server(ip, port)
	} else if strings.HasPrefix(select_mode, "client") {
		fmt.Print("Enter server ip: ")
		fmt.Scan(&ip)

		fmt.Print("Enter server port: ")
		fmt.Scan(&port)

		clientserver.Client(ip, port)
	} else if strings.HasPrefix(select_mode, "viewer") {
		fmt.Print("Enter server ip: ")
		fmt.Scan(&ip)

		fmt.Print("Enter server port: ")
		fmt.Scan(&port)

		clientserver.Viewer(ip, port)
	} else {
		goto repeat
	}
}
