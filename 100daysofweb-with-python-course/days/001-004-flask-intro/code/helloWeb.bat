call C:\ProgramData\Anaconda3\Scripts\activate.bat
call conda deactivate
call conda activate flaskEnv1
set FLASK_APP=demo.py
flask run
pause