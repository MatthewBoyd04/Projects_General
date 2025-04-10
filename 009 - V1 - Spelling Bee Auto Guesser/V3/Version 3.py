# -*- coding: utf-8 -*-
"""
Created on Thu Feb 15 22:40:19 2024

@author: chunk
"""
import pyautogui
import time

def Guess(guess): 
    pyautogui.write(guess)
    pyautogui.press('enter')
    print("Guessed:" + guess)
    time.sleep(0.5)
    
def isWordBanned(word, banned_letters):
    invalid = False
    if len(word) < 4: 
        invalid = True
    for letter in banned_letters:
        if letter in word:
            
            # print("Removed: ", word, " Containts ", letter)
            invalid = True
    if invalid == False:         
        with open("Temp_Dictionary.txt", 'a') as file:
            file.write(word + '\n')

def DoesWordContainKeyLetter(word, KeyLetter):
    valid = False
    if KeyLetter in word:
        print("Added: ", word, "Contains", KeyLetter)
        valid = True
        
    if valid == True:         
        with open("ValidGuesses.txt", 'a') as file:
            file.write(word + '\n')


Letters = []
KeyLetter = []

for i in range(6):
    letter = input("Enter letter {}: ".format(i+1))
    Letters.append(letter)

# Get user input for the key letter
x = input("Enter the key letter: ")
KeyLetter.append(x)

alphabet = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","-",".","1","2","3","4","5","6","7","8","9","0","'","/"]
allowed_letters = Letters + KeyLetter
banned_letters = [letter for letter in alphabet if letter not in allowed_letters]

with open("Temp_Dictionary.txt", 'w') as file:
    file.write("")
with open("ValidGuesses.txt", 'w') as file:
    file.write("")
    
with open('words.txt', 'r') as file:
    words = file.read().split()
    for word in words:
        word = word.lower()
        isWordBanned(word,banned_letters)

with open('Temp_Dictionary.txt', 'r') as file:
    words = file.read().split()
    for word in words:
        word = word.lower()
        DoesWordContainKeyLetter(word,KeyLetter[0])

with open('ValidGuesses.txt', 'r') as file:
    words = file.read().split()
    for word in words:
        Guess(word)
