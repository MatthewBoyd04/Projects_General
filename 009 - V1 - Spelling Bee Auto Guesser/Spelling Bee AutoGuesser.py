# -*- coding: utf-8 -*-
"""
Created on Sun Jan  7 06:13:27 2024

@author: chunk
"""
import pyautogui
import time
import enchant

def is_word_in_dictionary(word):
    dictionary = enchant.Dict("en_US")
    return dictionary.check(word)

#Spelling bee solver test 1
def Guess(guess):
    if is_word_in_dictionary(guess):    
        pyautogui.write(guess)
        pyautogui.press('enter')
        print("Guessed:" + guess)
        time.sleep(0.5)
    else:
        print("Skipped:" + guess)

    
letters = ["a", "l", "i", "w", "n", "g"]
KeyLetter = "f"

time.sleep(5)

"""4 Letter Words"""
for control in range(4):
    for x in range(6):
        for y in range(6):
            for z in range(6):
                if control == 0: 
                    guess = KeyLetter + letters[x] + letters[y] + letters[z]
                elif control == 1: 
                    guess = letters[x] + KeyLetter + letters[y] + letters[z]
                elif control == 2: 
                    guess = letters[x] + letters[y] + KeyLetter + letters[z]
                elif control == 3: 
                    guess = letters[x] + letters[y] + letters[z] + KeyLetter
                Guess(guess)        

"""5 Letter Words"""
for control in range(5):
    for x in range(6):
        for y in range(6):
            for z in range(6):
                for a in range(6):
                    if control == 0: 
                        guess = KeyLetter + letters[x] + letters[y] + letters[z] + letters[a]
                    elif control == 1: 
                        guess = letters[x] + KeyLetter + letters[y] + letters[z] + letters[a]
                    elif control == 2: 
                        guess = letters[x] + letters[y] + KeyLetter + letters[z] + letters[a]
                    elif control == 3: 
                        guess = letters[x] + letters[y] + letters[z] + KeyLetter + letters[a]
                    elif control == 4: 
                        guess = letters[x] + letters[y] + letters[z] + letters[a] + KeyLetter
                    Guess(guess)        

"""6 Letter Words"""
for control in range(5):
    for x in range(6):
        for y in range(6):
            for z in range(6):
                for a in range(6):
                    for b in range(6):
                        if control == 0: 
                            guess = KeyLetter + letters[x] + letters[y] + letters[z] + letters[a] + letters[b]
                        elif control == 1: 
                            guess = letters[x] + KeyLetter + letters[y] + letters[z] + letters[a] + letters[b]
                        elif control == 2: 
                            guess = letters[x] + letters[y] + KeyLetter + letters[z] + letters[a] + letters[b]
                        elif control == 3: 
                            guess = letters[x] + letters[y] + letters[z] + KeyLetter + letters[a] + letters[b]
                        elif control == 4: 
                            guess = letters[x] + letters[y] + letters[z] + letters[a] + KeyLetter + letters[b]
                        elif control == 5: 
                            guess = letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter
                        Guess(guess) 
                
"""7 Letter Words"""
for control in range(5):
    for x in range(6):
        for y in range(6):
            for z in range(6):
                for a in range(6):
                    for b in range(6):
                        for c in range(6):
                            if control == 0: 
                                guess = KeyLetter + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + letters[c]
                            elif control == 1: 
                                guess = letters[x] + KeyLetter + letters[y] + letters[z] + letters[a] + letters[b] + letters[c]
                            elif control == 2: 
                                guess = letters[x] + letters[y] + KeyLetter + letters[z] + letters[a] + letters[b] + letters[c]
                            elif control == 3: 
                                guess = letters[x] + letters[y] + letters[z] + KeyLetter + letters[a] + letters[b] + letters[c]
                            elif control == 4: 
                                guess = letters[x] + letters[y] + letters[z] + letters[a] + KeyLetter + letters[b] + letters[c]
                            elif control == 5: 
                                guess = letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[c]
                            elif control == 6: 
                                guess = letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter
                            Guess(guess) 
                        
for control in range(6):
    for x in range(6):
        for y in range(6):
            for z in range(6):
                for a in range(6):
                    for b in range(6):
                        for c in range(6):
                            for d in range(6):
                                if control == 0:
                                    guess = KeyLetter + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + letters[c] + letters[d]
                                elif control == 1: 
                                    guess = letters[x] + KeyLetter + letters[y] + letters[z] + letters[a] + letters[b] + letters[c] + letters[d]
                                elif control == 2: 
                                    guess = letters[x] + letters[y] + KeyLetter + letters[z] + letters[a] + letters[b] + letters[c] + letters[d]
                                elif control == 3: 
                                    guess = letters[x] + letters[y] + letters[z] + KeyLetter + letters[a] + letters[b] + letters[c] + letters[d]
                                elif control == 4: 
                                    guess = letters[x] + letters[y] + letters[z] + letters[a] + KeyLetter + letters[b] + letters[c] + letters[d]
                                elif control == 5: 
                                    guess = letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[c] + letters[d]
                                elif control == 6: 
                                    guess = letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[d]
                                elif control == 7: 
                                    guess = letters[d] + letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter
                                Guess(guess) 
                                   

for control in range(7):
    for x in range(6):
        for y in range(6):
            for z in range(6):
                for a in range(6):
                    for b in range(6):
                        for c in range(6):
                            for d in range(6):
                                for e in range(6):
                                    if control == 0:
                                        guess = KeyLetter + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + letters[c] + letters[d] + letters[e]
                                    elif control == 1: 
                                        guess = letters[x] + KeyLetter + letters[y] + letters[z] + letters[a] + letters[b] + letters[c] + letters[d] + letters[e]
                                    elif control == 2: 
                                        guess = letters[x] + letters[y] + KeyLetter + letters[z] + letters[a] + letters[b] + letters[c] + letters[d] + letters[e]
                                    elif control == 3: 
                                        guess = letters[x] + letters[y] + letters[z] + KeyLetter + letters[a] + letters[b] + letters[c] + letters[d] + letters[e]
                                    elif control == 4: 
                                        guess = letters[x] + letters[y] + letters[z] + letters[a] + KeyLetter + letters[b] + letters[c] + letters[d] + letters[e]
                                    elif control == 5: 
                                        guess = letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[c] + letters[d] + letters[e]
                                    elif control == 6: 
                                        guess = letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[d] + letters[e]
                                    elif control == 7: 
                                        guess = letters[d] + letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[e]
                                    elif control == 8: 
                                        guess = letters[d] + letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + letters[e] + KeyLetter
                                    Guess(guess) 

for control in range(8):
    for x in range(6):
        for y in range(6):
            for z in range(6):
                for a in range(6):
                    for b in range(6):
                        for c in range(6):
                            for d in range(6):
                                for e in range(6):
                                    for f in range(6):
                                        if control == 0:
                                            guess = KeyLetter + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + letters[c] + letters[d] + letters[e] + letters[f]
                                        elif control == 1: 
                                            guess = letters[x] + KeyLetter + letters[y] + letters[z] + letters[a] + letters[b] + letters[c] + letters[d] + letters[e] + letters[f]
                                        elif control == 2: 
                                            guess = letters[x] + letters[y] + KeyLetter + letters[z] + letters[a] + letters[b] + letters[c] + letters[d] + letters[e] + letters[f]
                                        elif control == 3: 
                                            guess = letters[x] + letters[y] + letters[z] + KeyLetter + letters[a] + letters[b] + letters[c] + letters[d] + letters[e] + letters[f]
                                        elif control == 4: 
                                            guess = letters[x] + letters[y] + letters[z] + letters[a] + KeyLetter + letters[b] + letters[c] + letters[d] + letters[e] + letters[f]
                                        elif control == 5: 
                                            guess = letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[c] + letters[d] + letters[e] + letters[f]
                                        elif control == 6: 
                                            guess = letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[d] + letters[e] + letters[f]
                                        elif control == 7: 
                                            guess = letters[d] + letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + KeyLetter + letters[e] + letters[f]
                                        elif control == 8: 
                                            guess = letters[d] + letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + letters[e] + KeyLetter + letters[f]
                                        elif control == 8: 
                                            guess = letters[d] + letters[c] + letters[x] + letters[y] + letters[z] + letters[a] + letters[b] + letters[e] + letters[f] + KeyLetter
                                        Guess(guess) 

