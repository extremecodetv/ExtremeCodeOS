package shell

import (
	"bufio"
	"fmt"
	"os"
	"os/user"
	"runtime"
	"strings"

	"github.com/yosa12978/PickleShell/internal/handlers"
)

const (
	CURRENT_OS string = runtime.GOOS
)

func Run() {
	handlers.ClearHandler()
	fmt.Println("==============================================")
	fmt.Println("                 PICKLE SHELL                 ")
	fmt.Println("                 version 0.1                  ")
	fmt.Println("==============================================")
	fmt.Printf("OS - %s\n\r\n\r", CURRENT_OS)

	user, err := user.Current()
	if err != nil {
		panic(err)
	}
	reader := bufio.NewScanner(os.Stdin)
	for {
		cwd, err := os.Getwd()
		if err != nil {
			panic(err)
		}
		fmt.Printf("%s - %s $", user.Username, cwd)

		reader.Scan()
		input := reader.Text()
		args := strings.Split(input, " ")

		switch strings.ToLower(args[0]) {
		case "exit":
			handlers.ExitHandler()
		case "clear":
			handlers.ClearHandler()
		case "cd":
			handlers.CdHandler(args[1:])
		case "ls":
			handlers.LsHandler(cwd)
		case "cat":
			handlers.CatHandler(args[1:])
		case "touch":
			handlers.TouchHandler(args[1:])
		case "mkdir":
			handlers.MkdirHandler(args[1:])
		case "rm":
			handlers.RmHandler(args[1:])
		case "echo":
			handlers.EchoHandler(args[1:])
		case "getenv":
			handlers.GetenvHandler(args[1])
		case "setenv":
			handlers.SetenvHandler(args[1], args[2])
		default:
			if handlers.DefaultHandler(args) == 1 {
				fmt.Fprintf(os.Stderr, "terminal error: unknown command - %s\n", args[0])
			}
		}
	}
}
