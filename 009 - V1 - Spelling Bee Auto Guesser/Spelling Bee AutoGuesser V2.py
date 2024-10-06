# -*- coding: utf-8 -*-
"""
Created on Sun Jan  7 16:50:59 2024

@author: chunk
"""

import pyautogui
import time
import enchant
from itertools import product

def is_word_in_dictionary(word):
    dictionary = enchant.Dict("en_US")
    return dictionary.check(word)

def guess_and_sleep(guess_list):
    for guess in guess_list:
        if is_word_in_dictionary(guess):
            pyautogui.write(guess)
            pyautogui.press('enter')
            print("Guessed:", guess)
            time.sleep(0.5)
        else:
            print("Skipped:", guess)


def generate_guesses(letters, key_letter, length):
    return [''.join(combination) for combination in product(letters, repeat=length-1)]  # assuming the key_letter is at the beginning

def solve_spelling_bee(letters, key_letter):
    time.sleep(5)

    for length in range(4, 12):
        guesses = generate_guesses(letters, key_letter, length)
        guess_and_sleep([key_letter + guess for guess in guesses])

if __name__ == "__main__":
    letters = ["a", "l", "i", "w", "n", "g"]
    key_letter = "f"
    
    solve_spelling_bee(letters, key_letter)
