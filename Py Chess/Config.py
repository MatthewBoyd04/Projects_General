#----------Header----------
# Project: PyChess
# Classes: Config
# Creation Date: 10/04/2025
# Last Update: 10/04/2025
# Author: Matthew Boyd
# Language: Python
#--------------------------

from enum import Enum, auto

class GameType(Enum):
    DEFAULT = auto()
    SOVERIEGN = auto()
    FAIRY = auto()

class GameConfig:
    def __init__(self, gameType: GameType):
        if gameType == GameType.DEFAULT:
            print("Default Game Selected")
            self.squares = 8
            self.spriteDirectory = "Sprites_Default"
            self.gameDirectory = ""   #UPDATE ME IN LATER VERSIONS

        elif gameType == GameType.SOVERIEGN:
            print("Soveriegn Game Selected")
            self.squares = 16
            self.spriteDirectory = "" #UPDATE ME IN LATER VERSIONS
            self.gameDirectory = ""   #UPDATE ME IN LATER VERSIONS

        elif gameType == GameType.FAIRY:
            print("Fairy Game Selected")
            self.squares = 8
            self.spriteDirectory = "" #UPDATE ME IN LATER VERSIONS
            self.gameDirectory = ""   #UPDATE ME IN LATER VERSIONS

    def getSquares(self):
        return self.squares
    
    def getSpriteDirectory(self):
        return self.spriteDirectory

    def getGameDirectory(self):
        return self.gameDirectory

class DisplayPreference(Enum):
    _4K = auto()
    _2K = auto() 
    _HD = auto()

class UserPreference(Enum):
    DEFAULT = auto()
    STYLE1 = auto()
    STYLE2 = auto()
    

class UserConfig:
    def __init__(self, userPreference: UserPreference, displayPreference: DisplayPreference):

        self.setStyle(userPreference)
        self.setDisplay(displayPreference)

    def setStyle(self, userPreference: UserPreference): 
        if userPreference == UserPreference.DEFAULT:
            print("User Preference Set To: Default")
            self.gridColorLight = "#fbf5de" #Light
            self.gridColorDark = "#f8e7bb" #Dark

        elif userPreference == UserPreference.STYLE1:
            print("User Preference Set To: STYLE1")
            self.gridColorLight = "#111111"  #UPDATE ME IN LATER VERSIONS
            self.gridColorDark = "#FFFFFF"   #UPDATE ME IN LATER VERSIONS

        elif userPreference == UserPreference.STYLE2:
            print("User Preference Set To: STYLE2")
            self.gridColorLight = "#555555"  #UPDATE ME IN LATER VERSIONS
            self.gridColorDark = "#AAAAAA"   #UPDATE ME IN LATER VERSIONS

        return
    
    def setDisplay(self, displayPreference: DisplayPreference):
        
        if displayPreference == DisplayPreference._HD:
            self.winHeight = 600
            self.winWidth = 600

            borderDefault = 25
            self.borderLeft = borderDefault
            self.borderRight = borderDefault
            self.borderTop = borderDefault
            self.borderBottom = borderDefault

        elif displayPreference == DisplayPreference._2K:
            self.winHeight = 900
            self.winWidth = 1200

            borderDefault = 50
            self.borderLeft = borderDefault
            self.borderRight = borderDefault
            self.borderTop = borderDefault
            self.borderBottom = borderDefault

        elif displayPreference == DisplayPreference._4K:
            self.winHeight = 1800
            self.winWidth = 2400

            borderDefault = 100
            self.borderLeft = borderDefault
            self.borderRight = borderDefault
            self.borderTop = borderDefault
            self.borderBottom = borderDefault

        return
    

    def getGridColorLight(self):
        return self.gridColorLight
    
    def getGridColorDark(self):
        return self.gridColorDark
    
    def getBorderTop(self):
        return self.borderTop
    
    def getBorderBottom(self):
        return self.borderBottom
    
    def getBorderLeft(self):
        return self.borderLeft

    def getBorderRight(self):
        return self.borderRight    
    
    def getWinHeight(self):
        return self.winHeight
    
    def getWinWidth(self):
        return self.winWidth
        
    