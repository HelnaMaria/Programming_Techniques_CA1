import sqlite3

conn = sqlite3.connect("easydrive.db")
cursor = conn.cursor()

for row in cursor.execute("SELECT * FROM customers"):
    print(row)
    
    
    
