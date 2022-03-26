
from colorama import init, Fore, Back, Style
from ezprint import *
from tkinter import *
import threading
import random
import time
import os


user = 'Потохер'
age = '472'
money = 30
weapon = None


screen_saver_thread = None


def choose(max = 3):
	c = input('>>>')
	try:
		c = int(c)
	except:
		return choose(max = max)

	if c > 0 and c <= max:
		return str(c)

	return choose(max = max)


def cls():
	os.system('cls')


class item:

	def __init__(self, name, desc, damage, cost):
		self.name = name
		self.desc = desc
		self.damage = damage
		self.cost = cost


class hero:

	def __init__(self, name, age, des, dam, den):
		self.name = name
		self.age = age
		self.des = des
		self.dam = dam
		self.den = den


def printkrasivo(s):
	s = s + '\n'
	strtoprint = ''
	for i in s:
		strtoprint = strtoprint + str(i)
		sys.stdout.write('\r\r' + (strtoprint) + '')
		if i != ' ':
			time.sleep(0.05)
		else:
			pass


#heroes
gnom = hero('Гном', random.randint(60, 140), 'Гномы обитают в подземелье. Они не опасны, пока их не разозлить', 5, 0)
dragon = hero('Дракон', random.randint(400, 600), 'Дракон очень сверепое существо. Остерегайтесь его в замке', 14, 1)
elf = hero('Эльф', random.randint(120, 340), 'Эльфы стреляют своими магическими стрелами.', 10, 1)
trader = hero('Торговец', random.randint(40, 100), 'Торгует всем что есть в это мире.', 1, 0)
villager = hero('Житель', random.randint(20, 40), 'Простой житель. Ничего не умеет. Ничего не делает.', 0, 0)
old_villager = hero('Старый житель', random.randint(50, 85), 'Старый житель. Живет в избушке на пенсии', 0, 0)
young_villager = hero('Молодой житель', random.randint(10, 18), 'Молодой житель. Еще учится в школе.', 0, 0)
nerut = hero('Нерут', 45, 'Шахтёр коротый лишился глаза сражаясь с эльфом', 3, 1)
#items
wooden_stick = item('Палка', 'Палка из дерева. Проще её сжечь чем кого-нибудь ей убить', 1, 15)
torch = item('Факел', 'Факел для освещения дороги.', 2, 35)
small_sword = item('Маленький меч', 'Простой меч. Наносит мало урона.', 3, 100)
bow = item('Лук эльфа', 'Лук стреляющий магическими стрелами', 10, 300)

items = [wooden_stick, torch, small_sword, bow]



# h = people(user, age, 'Ваш перссонаж бродит по темным уголкам этого средневекового века. Он ищет не только приключения, но и семь тоинственных душ')
menu = None
create_person = None


def menu():
	global menu
	menu = Tk()

	menu.title('Adventures of the Hero')
	menu.geometry('450x450')
	menu.config(bg = '#1FA7E1')
	menu.resizable(0, 0)

	label = Label(menu, text = 'Menu', bg='#1FA7E1', fg='white')
	label.config(font = ('Arial', 25, 'bold'))
	label.place(x=180, y=30)
	
	button = Button(menu, text = 'START', width=15, command=create_person)
	button.config(font = ('Arial', 15, 'bold'))
	button.place(x=130, y=100)

	button = Button(menu, text = 'CONTINUE', width=15, command=create_person)
	button.config(font = ('Arial', 15, 'bold'))
	button.place(x=130, y=170)

	button = Button(menu, text = 'SETTINGS', width=15)
	button.config(font = ('Arial', 15, 'bold'))
	button.place(x=130, y=240)

	button = Button(menu, text = 'EXIT', width=15, command=menu.destroy)
	button.config(font = ('Arial', 15, 'bold'))
	button.place(x=130, y=310)

	menu.mainloop()
	
 
def create_person():
	global create_person

	def con():
		set_user_data(entry, entry1)
		game()

	menu.destroy()
	create_person = Tk()
	create_person.resizable(0, 0)

	create_person.title('Adventures of the Hero')
	create_person.geometry('450x450')
	create_person.config(bg = '#1FA7E1')

	label = Label(create_person, text = 'Input name: ', bg='#1FA7E1', fg='white')
	label.config(font = ('Arial', 20, 'bold'))
	label.place(x=130, y=30)

	entry = Entry(create_person, width = 20, )
	entry.config(font = ('Arial', 15, 'bold'))
	entry.place(x=130, y=70)

	label = Label(create_person, text = 'Input Age: ', bg='#1FA7E1', fg='white')
	label.config(font = ('Arial', 20, 'bold'))
	label.place(x=130, y=110)

	entry1 = Entry(create_person, width = 20)
	entry1.config(font = ('Arial', 15, 'bold'))
	entry1.place(x=130, y=150)

	button = Button(create_person, text = 'Create person', width=15, command=con)
	button.config(font = ('Arial', 15, 'bold'))
	button.place(x=130, y=190)

	create_person.mainloop()
	try:
		screen_saver_thread.join()
	except:
		pass

def inv():
	global inv
	
	inv = Tk()

	inv.title('Adventures of the Hero')
	inv.geometry('450x450')
	inv.config(bg = '#1FA7E1')
	inv.resizable(0, 0)

	game.mainloop()


def set_user_data(entry1, entry2):
	global user
	global age
	user = entry1.get()
	age = entry2.get()


def screen_saver():
	strs = []
	strs.append('')
	strs.append(' ▄▄▄      ▓█████▄  ██▒   █▓▓█████  ███▄    █ ▄▄▄█████▓ █    ██  ██▀███  ▓█████   ██████ ') 
	strs.append('▒████▄    ▒██▀ ██▌▓██░   █▒▓█   ▀  ██ ▀█   █ ▓  ██▒ ▓▒ ██  ▓██▒▓██ ▒ ██▒▓█   ▀ ▒██    ▒ ') 
	strs.append('▒██  ▀█▄  ░██   █▌ ▓██  █▒░▒███   ▓██  ▀█ ██▒▒ ▓██░ ▒░▓██  ▒██░▓██ ░▄█ ▒▒███   ░ ▓██▄   ') 
	strs.append('░██▄▄▄▄██ ░▓█▄   ▌  ▒██ █░░▒▓█  ▄ ▓██▒  ▐▌██▒░ ▓██▓ ░ ▓▓█  ░██░▒██▀▀█▄  ▒▓█  ▄   ▒   ██▒') 
	strs.append(' ▓█   ▓██▒░▒████▓    ▒▀█░  ░▒████▒▒██░   ▓██░  ▒██▒ ░ ▒▒█████▓ ░██▓ ▒██▒░▒████▒▒██████▒▒') 
	strs.append(' ▒▒   ▓▒█░ ▒▒▓  ▒    ░ ▐░  ░░ ▒░ ░░ ▒░   ▒ ▒   ▒ ░░   ░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░░░ ▒░ ░▒ ▒▓▒ ▒ ░') 
	strs.append('  ▒   ▒▒ ░ ░ ▒  ▒    ░ ░░   ░ ░  ░░ ░░   ░ ▒░    ░    ░░▒░ ░ ░   ░▒ ░ ▒░ ░ ░  ░░ ░▒  ░ ░') 
	strs.append('  ░   ▒    ░ ░  ░      ░░     ░      ░   ░ ░   ░       ░░░ ░ ░   ░░   ░    ░   ░  ░  ░  ') 
	strs.append('      ░  ░   ░          ░     ░  ░         ░             ░        ░        ░  ░      ░  ') 
	strs.append('           ░           ░                                                                ') 
	strs.append(' ▒█████    █████▒')
	strs.append('▒██▒  ██▒▓██   ▒ ')
	strs.append('▒██░  ██▒▒████ ░ ')
	strs.append('▒██   ██░░▓█▒  ░ ')
	strs.append('░ ████▓▒░░▒█░    ')
	strs.append('░ ▒░▒░▒░  ▒ ░    ')
	strs.append('  ░ ▒ ▒░  ░      ')
	strs.append('░ ░ ░ ▒   ░ ░    ')
	strs.append('    ░ ░          ')
	strs.append('▄▄▄█████▓ ██░ ██ ▓█████     ██░ ██ ▓█████  ██▀███   ▒█████  ')
	strs.append('▓  ██▒ ▓▒▓██░ ██▒▓█   ▀    ▓██░ ██▒▓█   ▀ ▓██ ▒ ██▒▒██▒  ██▒')
	strs.append('▒ ▓██░ ▒░▒██▀▀██░▒███      ▒██▀▀██░▒███   ▓██ ░▄█ ▒▒██░  ██▒')
	strs.append('░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄    ░▓█ ░██ ▒▓█  ▄ ▒██▀▀█▄  ▒██   ██░')
	strs.append('  ▒██▒ ░ ░▓█▒░██▓░▒████▒   ░▓█▒░██▓░▒████▒░██▓ ▒██▒░ ████▓▒░')
	strs.append('  ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░    ▒ ░░▒░▒░░ ▒░ ░░ ▒▓ ░▒▓░░ ▒░▒░▒░ ')
	strs.append('    ░     ▒ ░▒░ ░ ░ ░  ░    ▒ ░▒░ ░ ░ ░  ░  ░▒ ░ ▒░  ░ ▒ ▒░ ')
	strs.append('  ░       ░  ░░ ░   ░       ░  ░░ ░   ░     ░░   ░ ░ ░ ░ ▒  ')
	strs.append('          ░  ░  ░   ░  ░    ░  ░  ░   ░  ░   ░         ░ ░  ')

	for i in strs:
		pwd(Fore.RED + i + '\n')
																				 

def shop():
	global money

	def show_shop():
		cls()
		p('==============')
		p('ТОГРОВАЯ ЛАВКА')
		p('==============')
		p('-' + trader.name)
		p('Добро пожаловать в торговую лавку. У нас ты можешь найти всё что желаешь.')
		p()
		p('У тебя ' + str(money) + ' монет')
		p()

	cls()
	p('==============')
	p('ТОГРОВАЯ ЛАВКА')
	p('==============')
	p('-' + trader.name)
	printkrasivo('Добро пожаловать в торговую лавку. У нас ты можешь найти всё что желаешь.')
	p()
	p('У тебя ' + str(money) + ' монет')
	p()
	while True:
		for item in items:
			p(str(items.index(item) + 1) + '    ' + item.name)
			p(item.desc)
			p('Урон: ' + str(item.damage) + '    Цена: ' + str(item.cost))
			p()

		p(str(len(items) + 1) + '    Exit')

		v = int(choose(max = len(items) + 1)) - 1

		if v == len(items):
			break

		if money >= items[v].cost:
			weapon = items[v]
			money = money - item.cost
			printkrasivo('Спасибо за покупку. Ждем тебе снова!')
			break
		else:
			printkrasivo('Видно у тебя не достаточно денег. Выбери что-то другое или подзаработай монет')
			input()
			show_shop()
			

def game():
	global money
	# try:
	# 	create_person.destroy()
	# except:
	# 	pass
	# screen_saver_thread.join()
#------------------------------------------------------------------------------------------------------------------------------
	stage = 0
	if stage == 0:
		p('==================')
		p('ЛЕСНОЕ КОРОЛЕВСТВО')
		p('==================')
		p('-' + villager.name)
		printkrasivo('Здравствуй, ' + user + ', какими судьбами тебя занесло в наши края?')
		p('')
		p('1.Я пришел в ваши края за семи магическими душами, разных существ.')
		p('2.Пришел найти своего друга - гнома Нерута. Ты случайно не знаешь его?')
		p('3.Я думаю тебе не обязательно знать это!')
		v1 = choose()

		if v1 == '1':
			cls()
			p('-' + villager.name)
			printkrasivo('Зачем тебе они? Ты ведь не обладаешь никакой силой, чтобы заполучить их!')
			p('')
			p('1.Я хочу стать самым могущественным существом в этом мире!')
			p('2.Я думаю тебе не надо знать об этом! Отведи меня к первой душе. Гном Нерут прячется в этих краях!')
			v7 = choose()
			if v7 == '1':
				cls()
				p('-' + villager.name)
				printkrasivo('Я думаю у тебя ничего не получится. Никто не обладал мощью семи существ!')
				p('')
				p('-' + user)
				printkrasivo('Просто отведи меня к моей первой душе! Гном Нерут.')
				p('')
				p('-' + villager.name)
				printkrasivo('Хорошо, пошли!')
				p('')
				time.sleep(5)
				cls()
				printkrasivo('- > - > - > - > - > - > - > - > - > - >')
				cls()
				p('-' + user)
				printkrasivo('Стой! Мне надо зайти в торговую лавку. Подожди меня тут.')
				time.sleep(5)
				p('')
				p('-' + villager.name)
				printkrasivo('Хорошо я жду!')
				time.sleep(4)
				shop()
			if v7 == '2':
				cls()
				p('-' + villager.name)
				printkrasivo('Хорошо, пошли!')
				p('')
				cls()
				printkrasivo('- > - > - > - > - > - > - > - > - > - >')
				cls()
				p('-' + user)
				printkrasivo('Стой! Мне надо зайти в торговую лавку. Подожди меня тут.')
				time.sleep(3)
				p('')
				p('-' + villager.name)
				printkrasivo('Хорошо я жду!')
				time.sleep(4)
				shop()
				cls()
				printkrasivo('- > - > - > - > - > - > - > - > - > - >')
				cls()
				p('-' + villager.name)
				printkrasivo('Вот мы подошли к шахте. Она за водопадом, иди туда и там ты найдешь Нерута. Удачи тебе!')
				time.sleep(5)

		if v1 == '2':
			cls()
			p('-' + villager.name)
			printkrasivo('Да, Я слышал о нем немного. Говорят он работает местным шахтером.')
			p('')
			p('1.Мог бы ты меня провести до шахты?')
			p('2.Подскажи пожалуйста мне дорогу.')
			p('')
			v2 = choose(max = 2)
			if v2 == '1':
				cls()
				p('-' + villager.name)
				printkrasivo('Да, конечно, но это будет стоить 15 монет.')
				p('')
				p('1.Хорошо, пошли!')
				p('2.Нет, спасибо! Подскажи мне пожайлуйста дорогу')
				v3 = choose(max = 2)
				if v3 == '1':
					cls()
					money = money - 15
					printkrasivo('- > - > - > - > - > - > - > - > - > - >')
					cls()
					p('-' + user)
					printkrasivo('Стой! Мне надо зайти в торговую лавку. Подожди меня тут.')
					time.sleep(3)
					p('')
					p('-' + villager.name)
					printkrasivo('Хорошо я жду!')
					time.sleep(1)
					shop()
					cls()
					printkrasivo('- > - > - > - > - > - > - > - > - > - >')
					cls()
					p('-' + villager.name)
					printkrasivo('Вот мы подошли к шахте. Она за водопадом, иди туда и там ты найдешь Нерута. Удачи тебе!')
					time.sleep(5)
				if v3 == '2':
					cls()
					p('-' + villager.name)
					printkrasivo('Иди прямо до деревни. Проходи мимо торговой лавки и там увидешь водопад. Под ним и будет его шахта!')
					p('')
					p('-' + user)
					printkrasivo('Спасибо!')
					time.sleep(5)
					cls()
					printkrasivo('- > - > - > - > - > - > - > - > - > - >')
					cls()
					p('-' + user)
					printkrasivo('Зайду я пожалуй в торговую лавку!')
					time.sleep(3)
					shop()
					cls()
					printkrasivo('- > - > - > - > - > - > - > - > - > - >')
					cls()
					p('-' + user)
					printkrasivo('Вот я и пришел к моей первой душе')
					time.sleep(5)
			if v2 == '2':
				printkrasivo('Иди прямо до деревни. Проходи мимо торговой лавки и там увидешь водопад. Под ним и будет его шахта!')
				p('')
				p('-' + user)
				printkrasivo('Спасибо!')
				time.sleep(5)
				cls()
				printkrasivo('- > - > - > - > - > - > - > - > - > - >')
				cls()
				p('-' + user)
				printkrasivo('Зайду я пожалуй в торговую лавку!')
				time.sleep(3)
				shop()
				cls()
				printkrasivo('- > - > - > - > - > - > - > - > - > - >')
				cls()
				p('-' + user)
				printkrasivo('Вот я и пришел к моей первой душе')
				time.sleep(5)
		if v1 == '3':
			cls()
			p('-' + villager.name)
			printkrasivo('Хорошо, Я просто хотел предложить тебе подзаработать немного денег. Я думаю в наших краях они тебе пригодятся! ')
			p('')
			p('1.Что мне нужно сделать?')
			p('2.Нет, спасибо. Мне надо найти моего друга Нерута. Ты не знаешь где он может быть?')
			v4 = choose(max = 2)
			if v4 == '1':
				cls()
				p('-' + villager.name)
				printkrasivo('Тебе нужно найти самоцвет. Он находится у старого купца.') 
				printkrasivo('Укради его если сможешь. Вернись сюда на рассвете, и получи вознагрождение!')
				printkrasivo('Возьми эту палку она тебе пригодится.')
				p('')
				p('1.Хорошо.')
				p('2.Нет, Спасибо!')
				v8 = choose(max=2)
				if v8 == '1':
					weapon = items[0]
					printkrasivo('Удачи тебе.')
				if v8 == '2':
					printkrasivo('Ну, не хочешь как хочешь. Так тебе подсказать дорогу к шахте?')
					p()
					p('1.Да')
					p('2.Нет, спасибо')
					v9 = choose(max = 2)
					if v9 == '1':
						cls()
						p('-' + villager.name)
						printkrasivo('Иди прямо до деревни. Проходи мимо торговой лавки и там увидешь водопад. Под ним и будет его шахта!')
						p('')
						p('-' + user)
						printkrasivo('Спасибо!')
						time.sleep(4)
						cls()
						printkrasivo('- > - > - > - > - > - > - > - > - > - >')
						cls()
						p('-' + user)
						printkrasivo('Зайду я пожалуй в торговую лавку!')
						time.sleep(3)
						shop()
						cls()
						printkrasivo('- > - > - > - > - > - > - > - > - > - >')
						cls()
						p('-' + user)
						printkrasivo('Вот я и пришел к моей первой душе')
						time.sleep(5)
					if v9 == '2':
						cls()
						p('-' + villager.name)
						printkrasivo('Будь аккуратней. В наших краях опасно ходить.')
						time.sleep(4)
						cls()
						printkrasivo('- > - > - > - > - > - > - > - > - > - >')
						cls()
						printkrasivo(user + ' заблудился и набрёл на дракона.')
						printkrasivo(Fore.RED + 'GAME OVER!')
			if v4 == '2':
				cls()
				p('-' + villager.name)
				printkrasivo('Обычно он заседает в своей шахте.')
				p('')
				p('1.Мог бы ты меня провести до шахты?')
				p('2.Подскажи пожалуйста мне дорогу.')
				v5 = choose(max = 2)
				if v5 == '1':
					cls()
					p('-' + villager.name)
					printkrasivo('Да, конечно, но это будет стоить 15 монет.')
					p('')
					p('1.Хорошо, пошли!')
					p('2.Нет, спасибо! Подскажи мне пожайлуйста дорогу')
					v6 = choose(max = 2)
					if v6 == '1':
						cls()
						money = money - 15
						printkrasivo('- > - > - > - > - > - > - > - > - > - >')
						cls()
						p('-' + user)
						printkrasivo('Стой! Мне надо зайти в торговую лавку. Подожди меня тут.')
						time.sleep(1)
						p('')
						p('-' + villager.name)
						printkrasivo('Хорошо я жду!')
						time.sleep(4)
						shop()
						cls()
						printkrasivo('- > - > - > - > - > - > - > - > - > - >')
						cls()
						p('-' + villager.name)
						printkrasivo('Вот мы подошли к шахте. Она за водопадом, иди туда и там ты найдешь Нерута. Удачи тебе!')
						time.sleep(5)
					if v6 == '2':
						cls()
						p('-' + villager.name)
						printkrasivo('Иди прямо до деревни. Проходи мимо торговой лавки и там увидешь водопад. Под ним и будет его шахта!')
						p('')
						p('-' + user)
						printkrasivo('Спасибо!')
						time.sleep(4)
						cls()
						printkrasivo('- > - > - > - > - > - > - > - > - > - >')
						cls()
						p('-' + user)
						printkrasivo('Зайду я пожалуй в торговую лавку!')
						time.sleep(3)
						shop()
						cls()
						printkrasivo('- > - > - > - > - > - > - > - > - > - >')
						cls()
						p('-' + user)
						printkrasivo('Вот я и пришел к моей первой душе')
						time.sleep(5)
				if v5 == '2':
					cls()
					p('-' + villager.name)
					printkrasivo('Иди прямо до деревни. Проходи мимо торговой лавки и там увидешь водопад. Под ним и будет его шахта!')
					p('')
					p('-' + user)
					printkrasivo('Спасибо!')
					time.sleep(5)
					cls()
					printkrasivo('- > - > - > - > - > - > - > - > - > - >')
					cls()
					p('-' + user)
					printkrasivo('Зайду я пожалуй в торговую лавку!')
					time.sleep(3)
					shop()
					cls()
					printkrasivo('- > - > - > - > - > - > - > - > - > - >')
					cls()
					p('-' + user)
					printkrasivo('Вот я и пришел к моей первой душе')
					time.sleep(5)
#------------------------------------------------------------------------------------------------------------------------------


if __name__ == '__main__':
	cls()
	# init(autoreset=True)
	# screen_saver_thread = threading.Thread(target = screen_saver)
	# screen_saver_thread.start()
	# menu()
	game()
