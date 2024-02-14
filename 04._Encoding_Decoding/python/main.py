text = "Hej hallå"
x = text.encode(encoding="utf-8",errors="namereplace")
print(x)
y = x.decode(encoding="utf-8")
print(y)
print('damn det kan man ikke, kun hvis man ikke giver den en specifik encoding')