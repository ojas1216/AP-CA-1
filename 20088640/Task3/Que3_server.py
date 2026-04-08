import socket
import sqlite3
import random

# ---------- DATABASE SETUP ----------
conn = sqlite3.connect("O:\\ADvance programmin\\20088640\\Task3\\easydrive.db", check_same_thread=False)
cursor = conn.cursor()

cursor.execute("""
CREATE TABLE IF NOT EXISTS customers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT,
    address TEXT,
    pps TEXT,
    license TEXT,
    reg_no TEXT
)
""")
conn.commit()

# ---------- SERVER SETUP ----------
server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(("127.0.0.1", 5001))
server.listen(5)

print("Server started")
print("Waiting for connection...\n")

while True:
    client, addr = server.accept()
    print("Connected:", addr)

    try:
        # ---------- RECEIVE DATA ----------
        data = client.recv(1024).decode()
        print("Received:", data)

        name, address, pps, license_doc = data.split("|")

        # ---------- GENERATE REG NUMBER ----------
        reg_no = "ED" + str(random.randint(1000, 9999))

        # ---------- STORE IN DATABASE ----------
        cursor.execute("""
        INSERT INTO customers (name, address, pps, license, reg_no)
        VALUES (?, ?, ?, ?, ?)
        """, (name, address, pps, license_doc, reg_no))

        conn.commit()
        print("Stored in database")

        # ---------- SEND RESPONSE ----------
        client.send(reg_no.encode())
        print("Sent Reg No:", reg_no)

    except Exception as e:
        print("Error:", e)

    finally:
        print("--------------------------")
        client.close()