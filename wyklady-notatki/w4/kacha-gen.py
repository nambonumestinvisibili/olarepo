print('Welcome to Kacha generator!')
print("You'll see some sentences Kacha is likely to say at a random time of the day")
print('Press N for next sentence, X to stop')
line = '-------------------------------'
print(line)


bank = ['Dimitar napisał', 'Ale zrobiłam siare', 'Paski ketonowe nie mają ketonów',
'Mam kaca', '13 h 12 min do konca zmiany',
 'Smaruję pięty', 'Ide spać', 
 'Jebany TIP', 'Moquito skills',
'Giovanni napisał',
'Daj blika', 
'Myślisz, że jeszcze napisze?', 
'Ja dziś nie wychodzę ',
'Jeszcze miesiąc i Londyn', 
'3h 25 min ',
'Ale mam kaca', 
'Paski ketonowe nie działają', 
'Mosquito skills ',
'Przesadziłam wczoraj', 
'Ale mam kaca moralnego', 
'Idę spać ',
'Zobaczę jak z Darem', 
'Won ',
'Kocham Cię z Bogiem', 
'2h 53 min ',
'XD',
'Nie chce mi się', 
'Śpię dziś u Dominika', 
'Nie napisał'
]



from random import *

while(input() != 'X'):
    rand = randrange(len(bank))
    print(bank[rand])

