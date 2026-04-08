import requests
from bs4 import BeautifulSoup
import csv
import os

# ---------- FILE PATH (SAVE INSIDE TASK4 FOLDER) ----------
file_path = r"O:\ADvance programmin\20088640\Task4\books.csv"

# ---------- STEP 1: FETCH WEBPAGE ----------
url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html"
response = requests.get(url)

# ---------- STEP 2: PARSE HTML ----------
soup = BeautifulSoup(response.text, "html.parser")
books = soup.find_all("article", class_="product_pod")

# ---------- STEP 3: EXTRACT DATA ----------
book_data = []

for book in books:
    # Book Name
    name = book.h3.a["title"]

    # Price
    price = book.find("p", class_="price_color").text

    # Rating
    rating_class = book.find("p", class_="star-rating")["class"]
    rating = rating_class[1]  # e.g., One, Two, Three...

    book_data.append([name, price, rating])

# ---------- STEP 4: STORE IN CSV ----------
with open(file_path, "w", newline="", encoding="utf-8") as file:
    writer = csv.writer(file)
    
    # Header
    writer.writerow(["Book Name", "Price", "Rating"])
    
    # Data
    writer.writerows(book_data)

print("Data successfully saved to books.csv")

# ---------- STEP 5: READ FROM CSV ----------
print("\n--- DATA FROM CSV FILE ---\n")

with open(file_path, "r", encoding="utf-8") as file:
    reader = csv.reader(file)
    
    # Skip header
    next(reader)

    for row in reader:
        print(f"Name: {row[0]} | Price: {row[1]} | Rating: {row[2]}")