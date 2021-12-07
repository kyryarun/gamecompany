strings = []
newline = ''
inp = input("파일이름 입력(.txt 붙여서): ")
path = './' + inp
try:
    with open(path, 'r',encoding='utf-8') as text:
        lines = text.readlines()
        for t in lines:
            for c in t:
                if c not in strings:
                    strings.append(c)
                    newline += c
except:
    with open(path, 'r') as text:
        lines = text.readlines()
        for t in lines:
            for c in t:
                if c not in strings:
                    strings.append(c)
                    newline += c

                    
with open(path, 'w') as text:
    text.writelines(newline)
