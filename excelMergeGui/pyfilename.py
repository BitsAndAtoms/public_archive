# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'simpleBTSoftware.ui'
#
# Created by: PyQt5 UI code generator 5.9.2
#
# WARNING! All changes made in this file will be lost!

from PyQt5 import QtCore, QtGui, QtWidgets

import os
from os import listdir
from os.path import isfile, join
from pandas import ExcelWriter
import pandas as pd
import xlsxwriter


class Ui_MainWindow(QtWidgets.QMainWindow):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(220, 351)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.verticalLayout_2 = QtWidgets.QVBoxLayout(self.centralwidget)
        self.verticalLayout_2.setObjectName("verticalLayout_2")
        self.verticalLayout = QtWidgets.QVBoxLayout()
        self.verticalLayout.setObjectName("verticalLayout")
        self.pushButton = QtWidgets.QPushButton(self.centralwidget)
        self.pushButton.setStyleSheet(
            "QPushButton {\n"
            "    background-color: red;\n"
            "    border-style: outset;\n"
            "    border-width: 2px;\n"
            "    border-radius: 10px;\n"
            "    border-color: beige;\n"
            "    font: bold 14px;\n"
            "    min-width: 10em;\n"
            "    padding: 6px;\n"
            "}"
        )
        self.pushButton.setObjectName("pushButton")
        self.verticalLayout.addWidget(self.pushButton)
        self.label = QtWidgets.QLabel(self.centralwidget)
        self.label.setText("")
        self.label.setObjectName("label")
        self.verticalLayout.addWidget(self.label)
        self.pushButton_2 = QtWidgets.QPushButton(self.centralwidget)
        self.pushButton_2.setStyleSheet(
            "QPushButton {\n"
            "    background-color: green;\n"
            "    border-style: outset;\n"
            "    border-width: 2px;\n"
            "    border-radius: 10px;\n"
            "    border-color: beige;\n"
            "    font: bold 14px;\n"
            "    min-width: 10em;\n"
            "    padding: 6px;\n"
            "}"
        )
        self.pushButton_2.setObjectName("pushButton_2")
        self.verticalLayout.addWidget(self.pushButton_2)
        self.verticalLayout_2.addLayout(self.verticalLayout)
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 220, 21))
        self.menubar.setObjectName("menubar")
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)
        self.establishConnections()
        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "BTSoft"))
        self.pushButton.setText(_translate("MainWindow", "Choose Folder"))
        self.pushButton_2.setText(_translate("MainWindow", "Combine Files"))

    def establishConnections(self):
        self.pushButton.clicked.connect(self.setInputFolder)
        self.pushButton_2.clicked.connect(self.writeOutputExcel)

    def setInputFolder(self):
        self.dirName = QtWidgets.QFileDialog().getExistingDirectory(
            None,
            "Select a directory of raw worm movies data (*.mov, *.avi, *.mp4)",
            options=QtWidgets.QFileDialog.DontUseNativeDialog,
        )
        self.label.setText("You have selected the folder : " + self.dirName)

    def writeOutputExcel(self):
        try:

            def loadScreeningExcel(fileName):
                if os.path.basename(fileName).split(".")[1] == "csv":
                    return pd.read_csv(fileName)
                elif os.path.basename(fileName).split(".")[1] == "xlsx":
                    return pd.read_excel(fileName, index_col=0)

            def writeToExcel(array, arrayOfFileNames, outputName):
                writer = pd.ExcelWriter(outputName, engine="xlsxwriter")
                for index, item in enumerate(array):
                    item.to_excel(writer, sheet_name=arrayOfFileNames[index])
                writer.save()

            def directTheFlow(folderPath):
                onlyfiles = [
                    loadScreeningExcel(join(folderPath, f))
                    for f in listdir(folderPath)
                    if isfile(join(folderPath, f))
                ]
                onlyfileNames = [
                    os.path.basename(f).split(".")[0]
                    for f in listdir(folderPath)
                    if isfile(join(folderPath, f))
                ]
                writeToExcel(
                    onlyfiles, onlyfileNames, os.getcwd() + "\\" + "output.xlsx"
                )

            directTheFlow(self.dirName)
            self.label.setText(
                "Successfuly created " + os.getcwd() + "\\" + "output.xlsx"
            )

        except:
            self.label.setText("Error please choose source folder with excel/csv")


if __name__ == "__main__":
    import sys

    app = QtWidgets.QApplication(sys.argv)
    MainWindow = QtWidgets.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())
