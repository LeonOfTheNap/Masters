# IDLE
 
# Exercise 1
# Create variables which will store data like your name (text), age (number), favourite meal (text) or favourite meal (text).
# Display the text using the print() function. Use the created variables
# Example:
# My name is Adam, I’m 15 years old, my favourite meal is pizza and my favourite game is Minecraft.
# Remember to convert the number to text (use str()). Use the + symbol to connect text to variables.
 
# ime = "Filip"
# godina = 12
# najdražeJelo = "pizzu"

# print("Moje ime je " + ime + ", imam " + str(godina) + " godina i volim jesti " + najdražeJelo + ".")

 
# Exercise 2
# Write a script which will let the user enter grades from three subjects and display their average.
# To get data from the user, use the input() function. 
# Remember that this function gets data as text and we need numbers to count the average
# Our grade should be 5 and not "5" because 5+5=10, and "5"+"5"="55". Use int() function.
# for example. int(input("enter your English grade: "))
# You can count an average by adding all the grades together and dividing the sum by their amount (the symbol of division is /).
 
#prosjek = zbroj / broj znamenki
#matematika = 5
#priroda = 2
#hrvatski = 4

# prosjek = 0
# zbroj = 0
# broj_znamenki = 0

# for i in range(3):
#     znamenka = int(input("Unesite ocjenu: "))
#     zbroj = zbroj + znamenka
#     broj_znamenki = broj_znamenki + 1

# prosjek = zbroj / broj_znamenki

# print("Prosjek triju znamenki je: " + str(prosjek))

 
# Exercise 3
# Translator - create a program which will translate 5 different words in your language to English.
# The user enters the words in their language and gets an answer:
 
# >> Enter a word to translate: przycisk
# Przycisk in English: button
 
# For unknown words the following message should appear:
# “Unfortunately, we do not have translation data for this word in our database yet.”
# Use the if elif else conditional statements.
# Use a while True loop so the program repeats itself all the time.
# Remember about indentation (tab button).
 
# stop = ""

# while(stop != "p"):
#     stop = input("Unesite hrvatsku riječ: ")
#     if(stop == "šalica"):
#         print(stop + " na engleskom je: mug")
#     elif(stop == "miš"):
#         print(stop + "na engleskom je: mouse")
#     elif(stop == "računalo"):
#         print(stop + "na engleskom je: computer")
#     elif(stop == "punjač"):
#         print(stop + "na engleskom je: charger")
#     elif(stop == "gumica"):
#         print(stop + "na engleskom je: eraser")
#     else:
#         print("Vaša riječ trenutno nije u riječniku. :(")



 
# Exercise 4
# Create a loop which will display numbers from -10 to 100.
# Use the range() function.

#hrvatska riječ za loop je petlja

# for i in range(-10, 101):
#     print(i)
 
 
# Exercise 5*
# Create an array named numbersArray and save 5 numbers in it.
# Using a loop, get each element of the table and display the squared value of it.
# Example:
# For the number 2 the following should be displayed: 2 squared is 4
# For the number 5: 5 squared is 25
# Use the len() function which returns the length of the array.
# Use a for loop to get all the elements from the array.

# numbersArray = [1,2,3,4,5]

# for i in numbersArray:
#     print("Kvadrat broja " + str(i) + " je: " + str(i * i))