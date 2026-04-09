import socket
import sqlite3
import uuid
import json

# Creating database and table
conn = sqlite3.connect("easydrive.db")
cursor = conn.cursor()

cursor.execute('''
CREATE TABLE IF NOT EXISTS customers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT,
    address TEXT,
    pps TEXT,
    license TEXT,
    reg_number TEXT
)
''')
conn.commit()

# Server setup
server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(("localhost", 5000))
server.listen(5)

print("\nServer is running and waiting for connections.....!\n")

while True:
    client_socket, addr = server.accept()
    print(f"Connected to {addr}")

    data = client_socket.recv(1024).decode()
    customer = json.loads(data)

    # Generate unique registration number
    reg_number = "ED-" + str(uuid.uuid4())[:8]

    # Store in database
    cursor.execute('''
    INSERT INTO customers (name, address, pps, license, reg_number)
    VALUES (?, ?, ?, ?, ?)
    ''', (customer['name'], customer['address'], customer['pps'], customer['license'], reg_number))

    conn.commit()

    # Sending registration number back to client
    client_socket.send(reg_number.encode())

    client_socket.close()