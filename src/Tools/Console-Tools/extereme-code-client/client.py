import socket
import os
from config import user_port , check_network_speed
from check_speed import check_net_speed
from colorama import Fore , Back , Style , init

init()

if check_network_speed == True:

	print("About connection speed:\n")

	check_net_speed()


try:
	print(Fore.BLUE + "Creating socket........")
	clent_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	print(Fore.GREEN + "Socket succesfully created")
except socket.error as err:
	print(Fore.RED + "CRITICAL ERROR: Can't create socket for connecting!" + "\n" + Fore.YELLOW + "Error info : " % (err))

	exit(1)

print(Fore.GREEN + "Creating port.......")

if user_port == 1023:

	print(Fore.RED + "Sorry! You can't open socket by this addres! Please , change it!")

	exit(1)


PORT = user_port

connect_to = input("Enter the host name for connecting : ")

if not connect_to :

	print("ERROR! You are not input host addres! Try again!")

	exit(1)

try:
    host_ip = socket.gethostbyname(connect_to)
except socket.gaierror:

	print ("there was an error resolving the host")
	exit(1)


try:

	print(Fore.BLUE + "Connecting to :" + host_ip + "socket in port:" + str(PORT))
	client_socket.connect((host_ip, PORT))

except:

     print(Fore.GREEN + "Succesfully connected to " + host_ip + "!")





