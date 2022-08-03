# MYRTEX.TestProject
/*1*/ SELECT * FROM Employees;
/*2*/ SELECT e.Id, e.FirstName, e.SecondName, e.LastName, s.Value  FROM Employees AS e INNER JOIN Salaries AS s ON e.SalaryId = s.Id AND s.Value > 10000;

/*4*/ UPDATE Salaries SET Value = 15000 WHERE VALUE < 15000;