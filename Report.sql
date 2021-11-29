SELECT CONCAT(committeeFirstName, ' ', committeeLastName) as 'Committee Member', donorTypeName, tblTargets.firstQuarterTarget, tblTargets.secondQuarterTarget, tblTargets.thirdQuarterTarget, tblTargets.fourthQuarterTarget
FROM tblDonorType, tblTargets
INNER JOIN tblCommitteeMember ON donorTypeID = tblCommitteeMember.donorTypeID
INNER JOIN tblCommitteeTargets ON tblCommitteeTargets.targetID = tblTargets.targetID
INNER JOIN tblCommitteeTargets as CommitteeTargets ON CommitteeTargets.committeeID = tblCommitteeMember.committeeID
INNER JOIN tblCommitteeTargets as CommitteeTarget ON CommitteeTargets.committeeID = tblCommitteeMember.committeeID