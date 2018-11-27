# Need to clean this a lot and implement in WPF
# thanks bbadh001 for the head start...
# https://github.com/bbadh001/Quiltmatician
import tkinter as tk
from tkinter.font import Font
from PIL import ImageTk, Image


class Square():
    def __init__(self, size, color):
        self.size = size
        self.color = color

class MainApplication(tk.Frame):

    def __init__(self, parent, *args, **kwargs):
        tk.Frame.__init__(self, parent, *args, **kwargs)
        self.parent = parent
        self.initGUI()
        self.parent.configure(background='#031424')
        self.initBitMap()
        self.paintGrid()

    def on_configure(self, event):
        self.gridCanvas.configure(scrollregion=self.gridCanvas.bbox('all'))

    def initGUI(self):

        self.parent.title("Оценка затрат ткани")
        self.parent.geometry("800x800")
        self.parent.resizable(width=False, height=False)

        # The size of the fabric
        self.gridLength = 1500
        self.gridWidth = 286

        title = tk.Label(self.parent, text="Оценка затрат ткани",
                         font="Consolas", foreground='white')
        title.place(x=270, y=1)
        title.configure(background='#031424')
        titleFont = Font(family="Consolas", size=20)
        title.configure(font=titleFont)

        self.inputCanvas = tk.Canvas(self.parent, width=752, height=215, background='#30415D', highlightthickness=1.6)
        self.inputCanvas.place(x=10, y=470)

        tk.Label(self.parent, text="Количество ткани 5 х 5 см: ", foreground='white',
                 background='#30415D', font=Font(family="Consolas", size=12)).place(x=20, y=475)
        tk.Label(self.parent, text="Количество ткани 10 х 10 см:  ", foreground='white',
                 background='#30415D', font=Font(family="Consolas", size=12)).place(x=20, y=505)
        tk.Label(self.parent, text="Количество ткани 20 х 20 см:  ", foreground='white',
                 background='#30415D', font=Font(family="Consolas", size=12)).place(x=20, y=535)
        tk.Label(self.parent, text="Количество ткани 50 х 50 см:  ", foreground='white',
                 background='#30415D', font=Font(family="Consolas", size=12)).place(x=20, y=565)
        tk.Label(self.parent, text="Количество ткани 100 х 100 см:  ", foreground='white',
                 background='#30415D', font=Font(family="Consolas", size=12)).place(x=20, y=595)

        self.FiveByFive = tk.Entry(self.parent, width=3,
                              foreground='black', highlightbackground='#30415D')
        self.FiveByFive.insert(0, "0")
        self.FiveByFive.place(x=370, y=480)
        self.ThreeHalfEntry = tk.Entry(self.parent, width=3, foreground='black', highlightbackground='#30415D')
        self.ThreeHalfEntry.insert(0, "0")
        self.ThreeHalfEntry.place(x=370, y=510)
        self.FourHalfEntry = tk.Entry(self.parent, width=3, foreground='black', highlightbackground='#30415D')
        self.FourHalfEntry.insert(0, "0")
        self.FourHalfEntry.place(x=370, y=540)
        self.SixHalfEntry = tk.Entry(self.parent, width=3, foreground='black', highlightbackground='#30415D')
        self.SixHalfEntry.insert(0, "0")
        self.SixHalfEntry.place(x=370, y=570)
        self.NineHalfEntry = tk.Entry(self.parent, width=3, foreground='black', highlightbackground='#30415D')
        self.NineHalfEntry.insert(0, "0")
        self.NineHalfEntry.place(x=370, y=600)

        tk.Label(self.parent, text="Понадобиться... ", foreground='white',
                 background='#30415D', font=Font(family="Consolas", size=25)).place(x=420, y=510)
        self.neededLengthLabel = tk.Label(self.parent, foreground='white', background='#30415D', font=Font(family="Consolas", size=25))
        self.neededLengthLabel.place(x=515, y=570)

        self.CalculateButton = tk.Button(self.parent, text="Подсчитывать", command=self.calculate, height=2, width=15,
                                         foreground='white', background='grey25', highlightcolor='grey25', highlightthickness=0, font=("Consolas", 13, "bold"))
        self.CalculateButton.place(x=100, y=625)

        self.ClearButton = tk.Button(self.parent, text="Сброс", command=self.clear, height=2, width=10,
                                     foreground='white', background='grey25', highlightthickness=0, font=("Consolas", 13, "normal"))
        self.ClearButton.place(x=250, y=625)

        self.gridCanvas = tk.Canvas(self.parent, width=750, height=400,
                                    background='#8EAEBD', highlightbackground='white', highlightthickness=2.5)
        # the y scrollbar
        self.scrollbar = tk.Scrollbar(self.parent, command=self.gridCanvas.yview)
        self.scrollbar.pack(side=tk.RIGHT, fill='y')
        self.scrollbar.place(x=753, y=52, width=13, height=404)
        # the x scrollbar
        self.scrollbar_h = tk.Scrollbar(self.parent, command=self.gridCanvas.xview, orient=tk.HORIZONTAL)
        self.scrollbar_h.pack(side=tk.BOTTOM, fill='x')
        self.scrollbar_h.place(x=10, y=440, width=745, height=13)
        # grid canvas
        self.gridCanvas.pack(side=tk.RIGHT)
        self.gridCanvas.place(x=10, y=50)
        self.gridCanvas.configure(yscrollcommand=self.scrollbar.set)
        self.gridCanvas.configure(xscrollcommand=self.scrollbar_h.set)

        self.placeLengthMarkings()

        self.gridCanvas.bind('<Configure>', self.on_configure)

        self.frame = tk.Frame(self.gridCanvas)
        self.gridCanvas.create_window((0, 0), window=self.frame, anchor='nw')

    def initBitMap(self):
        self.bitMap = [[0.0] * self.gridWidth for _ in range(self.gridLength)]

    def clearBitMap(self):
        for i in range(self.gridLength):
            for j in range(self.gridWidth):
                self.bitMap[i][j] = 0.0

    def placeLengthMarkings(self):
        lengthMarkString = "0"
        posY = 40
        for i in range(int(self.gridLength // 10 + 1)):
            self.gridCanvas.create_text(16, posY, text=lengthMarkString, font=("Consolas", 7, "normal"), fill='white')
            lengthMarkString = str(float(lengthMarkString) + 10)
            posY += 100

    def paintGrid(self):
        canvasX = 40
        canvasY = 40
        for i in range(self.gridLength):
            for j in range(self.gridWidth):
                self.gridCanvas.create_rectangle(canvasX, canvasY, canvasX + 10, canvasY + 10, fill='grey90')
                canvasX += 10
            canvasX = 40
            canvasY += 10

    def addShapeToBitMap(self, x, y, shape):
        xUpper = x + int(shape.size)
        yUpper = y + int(shape.size)
        for i in range(y, yUpper):
            for j in range(x, xUpper):
                self.bitMap[i][j] = shape.size

    def spotIsFree(self, x, y, shape):
        xUpper = x + int(shape.size)
        yUpper = y + int(shape.size)
        if (xUpper > self.gridWidth):
            return False
        for i in range(y, yUpper):
            for j in range(x, xUpper):
                if (self.bitMap[i][j] > 0):
                    return False
        return True

    def clearShape(self, curX, curY, dim):
        for i in range(curY, int(curY + dim)):
            for j in range(curX, int(curX + dim)):
                self.bitMap[i][j] = 0

    def getLengthNeeded(self):
        maxLength = 0
        for i in range(self.gridWidth):
            j = 0
            while (self.bitMap[j][i] != 0 and j < self.gridWidth):
                j += 1
            if (j > maxLength):
                maxLength = j
        return maxLength / 72

    def fillGrid(self, squareList):
        curX = 0
        curY = 0

        while (squareList):
            currentShape = squareList[0]
            squareList.pop(0)
            currentShapeHasBeenAdded = False
            curX = 0
            curY = 0
            while (curY < self.gridLength and not(currentShapeHasBeenAdded)):
                while(curX < self.gridWidth - currentShape.size and not(currentShapeHasBeenAdded)):
                    if (self.spotIsFree(curX, curY, currentShape)):
                        self.addShapeToBitMap(curX, curY, currentShape)
                        curX += currentShape.size
                        currentShapeHasBeenAdded = True
                    else:
                        curX += 1
                curX = 0
                curY += 1

    def paintShapes(self):
        shapeColor = {5: "#ffb3ba", 10: "#ffdfba",
                      20: "#ffffba", 50: "#baffc9", 100: "#b19cd9"}
        currentShapeDim = 0
        canvasX = 40
        canvasY = 40
        for i in range(self.gridLength):
            for j in range(self.gridWidth):
                currentShapeDim = self.bitMap[i][j]
                if (currentShapeDim > 0):
                    fillColor = shapeColor[self.bitMap[i][j]]
                    self.gridCanvas.create_rectangle(canvasX, canvasY, canvasX + 10 * currentShapeDim, canvasY + 10 * currentShapeDim, fill=fillColor, width=2, tag="shape")
                    self.clearShape(j, i, currentShapeDim)
                    self.paintShapeGridLines(canvasX, canvasY, currentShapeDim, fillColor)
                canvasX += 10
            canvasX = 40
            canvasY += 10

    def paintShapeGridLines(self, curX, curY, dim, color):
        for i in range(int(dim)):
            for j in range(int(dim)):
                self.gridCanvas.create_rectangle(curX + 10 * j, curY + 10 * i, curX + 10 * (j + 1), curY + 10 * (i + 1), fill=color, tag="shape")
        self.gridCanvas.create_line(curX, curY, curX + 10 * dim, curY, width=2, tag="shape")
        self.gridCanvas.create_line(curX, curY, curX, curY + 10 * dim, width=2, tag="shape")
        self.gridCanvas.create_line(curX, curY + 10 * dim, curX + 10 * dim, curY + 10 * dim, width=2, tag="shape")
        self.gridCanvas.create_line(curX + 10 * dim, curY, curX + 10 * dim, curY + 10 * dim, width=2, tag="shape")

    def clear(self):
        self.gridCanvas.delete("shape")
        self.FiveByFive.delete(0, "end")
        self.FiveByFive.insert(0, "0")
        self.ThreeHalfEntry.delete(0, "end")
        self.ThreeHalfEntry.insert(0, "0")
        self.FourHalfEntry.delete(0, "end")
        self.FourHalfEntry.insert(0, "0")
        self.SixHalfEntry.delete(0, "end")
        self.SixHalfEntry.insert(0, "0")
        self.NineHalfEntry.delete(0, "end")
        self.NineHalfEntry.insert(0, "0")

    def calculate(self):

        self.gridCanvas.delete("shape")

        if (not isinstance(int(self.NineHalfEntry.get()), int) or int(self.NineHalfEntry.get()) < 0):
            self.NineHalfEntry.delete(0, "end")
            self.NineHalfEntry.insert(0, "0")
        if (not isinstance(int(self.SixHalfEntry.get()), int) or int(self.SixHalfEntry.get()) < 0):
            self.SixHalfEntry.delete(0, "end")
            self.SixHalfEntry.insert(0, "0")
        if (not isinstance(int(self.FourHalfEntry.get()), int) or int(self.FourHalfEntry.get()) < 0):
            self.FourHalfEntry.delete(0, "end")
            self.FourHalfEntry.insert(0, "0")
        if (not isinstance(int(self.ThreeHalfEntry.get()), int) or int(self.ThreeHalfEntry.get()) < 0):
            self.ThreeHalfEntry.delete(0, "end")
            self.ThreeHalfEntry.insert(0, "0")
        if (not isinstance(int(self.FiveByFive.get()), int) or int(self.FiveByFive.get()) < 0):
            self.FiveByFive.delete(0, "end")
            self.FiveByFive.insert(0, "0")

        self.squareList = []
        for i in range(int(self.NineHalfEntry.get())):
            self.squareList.append(Square(100, "red"))
        for i in range(int(self.SixHalfEntry.get())):
            self.squareList.append(Square(50, "blue"))
        for i in range(int(self.FourHalfEntry.get())):
            self.squareList.append(Square(20, "green"))
        for i in range(int(self.ThreeHalfEntry.get())):
            self.squareList.append(Square(10, "yellow"))
        for i in range(int(self.FiveByFive.get())):
            self.squareList.append(Square(5, "orange"))

        tempSquareList = self.squareList.copy()
        self.initBitMap()
        self.fillGrid(tempSquareList)
        self.lengthNeeded = self.getLengthNeeded()
        self.neededLengthLabel.config(text=str(round(self.lengthNeeded, 3)) + " м")
        self.paintGrid()
        self.paintShapes()


if __name__ == "__main__":
    root = tk.Tk()
    MainApplication(root)  # .pack(side="top", fill="both", expand=True)
    root.mainloop()
