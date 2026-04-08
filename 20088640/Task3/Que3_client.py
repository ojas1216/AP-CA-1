import socket

print("EasyDrive Client Application\n")

# Take input from user
name = input("Enter Name: ")
address = input("Enter Address: ")
pps = input("Enter PPS Number: ")
license_doc = input("Enter Driving License: ")

# Create socket (TCP)
client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# Connect to server
client.connect(("127.0.0.1", 5001))
print("Connected to server")

# Send data
data = name + "|" + address + "|" + pps + "|" + license_doc
client.send(data.encode())

# Receive registration number
reg_no = client.recv(1024).decode()

print("\nRegistration Successful")
print("Your Registration Number:", reg_no)

client.close()