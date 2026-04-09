import socket
import json

# Collect user input
name = input("Enter Name: ")
address = input("Enter Address: ")
pps = input("Enter PPS Number: ")
license_doc = input("Enter Driving License: ")

customer = {
    "name": name,
    "address": address,
    "pps": pps,
    "license": license_doc
}

# Connect to server
client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(("localhost", 5000))

# Send data
client.send(json.dumps(customer).encode())

# Receive registration number
reg_number = client.recv(1024).decode()

print("\n✅ Registration Successful! \n")
print("Your Registration Number : ", reg_number)

client.close()