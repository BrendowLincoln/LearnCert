CREATE OR REPLACE VIEW CertificationFlatView as
SELECT
    c.Id as Id,
    c.Title as Title,
    c.LanguageType as LanguageType,
    c.ImageUrl,   
    (SELECT COUNT(1) FROM Question q inner join Module m on m.Id = q.ModuleId and m.CertificationId = c.Id) CountQuestions
FROM Certification c