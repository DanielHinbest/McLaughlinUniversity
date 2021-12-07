SELECT tblCampus.campusName as 'Campus Name', SUM(tblTargets.firstQuarterTarget) as 'Qrt 1', SUM(tblTargets.secondQuarterTarget) as 'Qrt 2', SUM(tblTargets.thirdQuarterTarget) as 'Qrt 3', SUM(tblTargets.fourthQuarterTarget) as 'Qrt 4' FROM tblCampus, ((tblProgramTargets INNER JOIN tblTargets ON tblProgramTargets.targetID = tblTargets.targetID) INNER JOIN tblPrograms ON tblPrograms.campusName = campusName)WHERE yearNo = 2021 GROUP BY tblCampus.campusName;

--SELECT tblCampus.campusName as 'Campus Name', SUM(firstQuarterTarget) as 'Qrt 1', SUM(secondQuarterTarget) as 'Qrt 2', SUM(thirdQuarterTarget) as 'Qrt 3', SUM(fourthQuarterTarget) as 'Qrt 4' 
--FROM tblTargets, (( tblCampus
--INNER JOIN tblProgramTargets ON tblProgramTargets.targetID = targetID)
--INNER JOIN tblPrograms ON tblPrograms.campusName = tblCampus.campusName)
--WHERE yearNo = 2021 
--GROUP BY tblCampus.campusName;