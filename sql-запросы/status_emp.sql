-- Удаляем текущее ограничение CHECK, если оно существует
ALTER TABLE [dbo].[employees] DROP CONSTRAINT IF EXISTS [chk_status];

-- Создаем новое ограничение CHECK с корректными значениями
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [chk_status] CHECK ([status_tech] IN (N'Активен', N'Неактивен', N'В отпуске'));