import requests
from bs4 import BeautifulSoup
import csv

# URL of the page to scrape
url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html"

# Sending request
response = requests.get(url)
soup = BeautifulSoup(response.text, "html.parser")

books = soup.find_all("article", class_="product_pod")

data = []

# Function to convert rating text to number
def get_rating(star_class):
    ratings = {
        "One": 1,
        "Two": 2,
        "Three": 3,
        "Four": 4,
        "Five": 5
    }
    return ratings.get(star_class, 0)

# Extracting the data
for book in books:
    name = book.h3.a["title"]
    
    price = book.find("p", class_="price_color").text.replace("£", "")
    price = "£" + price.strip()
    
    rating_class = book.find("p", class_="star-rating")["class"][1]
    rating = get_rating(rating_class)
    
    data.append([name, rating, price])

# Save datato CSV file
with open("books.csv", "w", newline="", encoding="utf-8-sig") as file:
    writer = csv.writer(file)
    writer.writerow(["Book Name", "Rating", "Price"])
    writer.writerows(data)

print(" Data saved to books.csv\n")

# Read and display CSV data
print("\n📄 Data from CSV:\n")

with open("books.csv", "r", encoding="utf-8") as file:
    reader = csv.reader(file)
    for row in reader:
        print(row)