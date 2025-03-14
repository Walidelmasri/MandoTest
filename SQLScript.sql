CREATE PROCEDURE ClassRegistrationReport
AS
BEGIN
    SELECT 
        c.ClassName AS [Class],
        t.TeacherName AS [Teacher Name],
        COUNT(cr.Student_ID) AS [Registrations],
        SUM(CASE WHEN cr.HasPaidFees = 1 THEN 1 ELSE 0 END) AS [Number Paid]
    FROM Class c
    INNER JOIN Teacher t ON c.Teacher_ID = t.Teacher_ID
    LEFT JOIN ClassRegistration cr ON c.Class_ID = cr.Class_ID
    GROUP BY c.ClassName, t.TeacherName;
END;
