import os
from os import listdir
from os.path import isfile, join
from pandas import ExcelWriter
import pandas as pd
import xlsxwriter


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
    writeToExcel(onlyfiles, onlyfileNames, os.getcwd() + "\\" + "output.xlsx")


if __name__ == "__main__":
    ExcelFileName = (
        r"E:\Sent from Cody\FDL Sunrise Attachments\Tier2ChemicalsInInventory (15).csv"
    )
    excelTableAsPandasDf = loadScreeningExcel(ExcelFileName)
    directTheFlow(r"E:\Sent from Cody\FDL Sunrise Attachments")