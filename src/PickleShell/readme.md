# 🥒 PickleShell

### shell для супер-дупер админов 

![PickleRick](https://upload.wikimedia.org/wikipedia/ru/b/ba/%D0%9E%D0%B3%D1%83%D1%80%D1%87%D0%B8%D0%BA_%D0%A0%D0%B8%D0%BA.jpg)

> Когда-то я поменяю bash в линуксе на PickleShell. - (C) Линус Торвальдс

## Компиляция

Windows
```
go build -o PickleShell.exe ./cmd/PickleShell/main.go
```

Linux
```
env GOOS=linux GOARCH=arm64 go build -o PickleShell ./cmd/PickleShell/main.go
```

[Компиляция go под свою ОС](https://habr.com/ru/post/249449/)