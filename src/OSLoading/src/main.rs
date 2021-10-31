use std::io::Write;

fn main() {
    loading_screen();
}

fn loading_screen(){
    output("Creating a new React app in /root/ReactChain/ZashecoinWallet/.temp");

    std::thread::sleep(std::time::Duration::from_millis(727));

    output("");
    output("Installing packages. This might take a couple of minutes.");

    std::thread::sleep(std::time::Duration::from_millis(15727));

    output("Installing react, react-dom, and react-scripts...");

    output("");

    let mut current = 1;
    loop{
        react(current);
        current += 1
    }

    output("");
}

fn output(text: &str){
    println!("{}", text)
}

fn react(packet_id: i32){
    for s in vec!['\\', '|', '/', '-']{
        print!("\r[...................] {} {}: pizda", s, packet_id);
        std::io::stdout().flush().unwrap();
        std::thread::sleep(std::time::Duration::from_millis(727));
    }
}