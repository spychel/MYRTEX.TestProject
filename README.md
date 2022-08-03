# MYRTEX.TestProject
/*1*/ SELECT * FROM Employees;
/*2*/ SELECT e.Id, e.FirstName, e.SecondName, e.LastName, s.Value  FROM Employees AS e INNER JOIN Salaries AS s ON e.SalaryId = s.Id AND s.Value > 10000;
/*3*/ 
BEGIN Tran
	SELECT SalaryId INTO #Temporary FROM Employees WHERE DATEDIFF(DAY, Birthdate, GETDATE()) >= CAST((70 * 365.25) AS INT);
	Delete FROM Employees WHERE DATEDIFF(DAY, Birthdate, GETDATE()) >= CAST((70 * 365.25) AS INT);
	DELETE Salaries FROM (Select SalaryId FROM #Temporary) AS q WHERE q.SalaryId = Salaries.Id;
	DROP TABLE #Temporary;
COMMIT Tran
/* Не знаю почему, но datediff считает на 1 день меньше, чтобы быть точнее нужно вместо DATEDIFF(DAY, Birthdate, GETDATE()) вставить (DATEDIFF(DAY, Birthdate, GETDATE()) + 1) */
/*4*/ UPDATE Salaries SET Value = 15000 WHERE VALUE < 15000;