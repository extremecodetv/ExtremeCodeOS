package handlers

import (
	"fmt"
	"io/ioutil"
	"os"
	"os/exec"
	"runtime"
	"strings"
)

func CdHandler(args []string) {
	path := strings.Join(args, " ")
	err := os.Chdir(path)
	if err != nil {
		fmt.Fprintf(os.Stderr, "Path not found - %s\n", path)
	}
}

func LsHandler(cwd string) {
	finfo, err := ioutil.ReadDir(cwd)
	if err != nil {
		fmt.Fprintf(os.Stderr, "%s\n", err.Error())
	}
	for _, v := range finfo {
		if v.IsDir() {
			fmt.Printf("%s [Directory]\n", v.Name())
			continue
		}
		fmt.Println(v.Name())
	}
}

func TouchHandler(args []string) {
	_, err := os.Create(args[0])
	if err != nil {
		fmt.Fprintf(os.Stderr, "%s\n", err.Error())
	}
}

func MkdirHandler(args []string) {
	err := os.Mkdir(args[0], os.ModePerm)
	if err != nil {
		fmt.Fprintf(os.Stderr, "%s\n", err.Error())
	}
}

func RmHandler(args []string) {
	err := os.Remove(args[0])
	if err != nil {
		fmt.Fprintf(os.Stderr, "%s\n", err.Error())
	}
}

func EchoHandler(args []string) {
	fmt.Println(strings.Join(args, " "))
}

func CatHandler(args []string) {
	for _, name := range args {
		file, err := ioutil.ReadFile(name)
		if err != nil {
			fmt.Fprintf(os.Stderr, "%s\n", err.Error())
		}
		fmt.Println(string(file))
	}
}

func ExitHandler() {
	os.Exit(0)
}

func ClearHandler() {
	cos := runtime.GOOS
	if cos == "windows" {
		cmd := exec.Command("cmd", "/c", "cls")
		cmd.Stdout = os.Stdout
		cmd.Run()
	} else {
		cmd := exec.Command("clear")
		cmd.Stdout = os.Stdout
		cmd.Run()
	}
}

func DefaultHandler(args []string) int {
	cmd := exec.Command(args[0], args[1:]...)
	cmd.Stdout = os.Stdout
	cmd.Stdin = os.Stdin
	cmd.Stderr = os.Stderr
	err := cmd.Run()
	if err != nil {
		return 1
	}
	return 0
}

func SetenvHandler(key string, value string) {
	err := os.Setenv(key, value)
	if err != nil {
		fmt.Fprintf(os.Stderr, "%s\n", err.Error())
	}
}

func GetenvHandler(key string) {
	res := os.Getenv(key)
	fmt.Println(res)
}
