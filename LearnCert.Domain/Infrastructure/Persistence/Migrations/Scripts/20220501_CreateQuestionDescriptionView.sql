CREATE OR REPLACE VIEW QuestionDescriptionView as
SELECT
    qd.Id as Id,
    CONCAT(m.Code, '.', q.Code) as Code,
    qd.Description as Description,
    qd.LanguageType as LanguageType,
    m.CertificationId as CertificationId,
    m.Title as ModuleTitle,
    q.Id as QuestionId
FROM QuestionDescription qd
         INNER JOIN Question q on q.Id = qd.QuestionId
         INNER JOIN Module m on m.Id = q.ModuleId
    