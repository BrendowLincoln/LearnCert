CREATE OR REPLACE VIEW QuestionView as
SELECT
    q.Id as Id,
    CONCAT(m.Code, '.', q.Code) as Code,
    q.Description as Description,
    c.Id as CertificationId,
    m.Title as ModuleTitle,
    c.LanguageType as LanguageType
FROM Question q
       INNER JOIN Module m on m.Id = q.ModuleId
       INNER JOIN Certification c on c.Id = m.CertificationId
    