SELECT campusName as 'Campus Name', SUM(tblTargets.firstQuarterTarget) as 'Qrt 1', SUM(tblTargets.secondQuarterTarget) as 'Qrt 2', SUM(tblTargets.thirdQuarterTarget) as 'Qrt 3', SUM(tblTargets.fourthQuarterTarget) as 'Qrt 4' 
FROM ((tblProgramTargets tblPrograms
INNER JOIN tblTargets ON tblProgramTargets.targetID = tblTargets.targetID)
INNER JOIN tblCampus ON tblPrograms.campusName = tblCampus.campusName)
WHERE yearNo = 2021 
GROUP BY campusName;