

CREATE EXTENSION IF NOT EXISTS pg_trgm;  -- Для триграммного поиска
CREATE EXTENSION IF NOT EXISTS unaccent;  -- Для удаления акцентов (по желанию, если нужно)

create table test_table(id text, title text, singer text);

CREATE INDEX idx_fulltext_search ON test_table
USING GIN ((to_tsvector('russian', title || ' ' || singer)));

CREATE INDEX idx_trgm ON test_table
USING GIN (title gin_trgm_ops, singer gin_trgm_ops);


SELECT *,
    ts_rank(to_tsvector('russian', title || ' ' || singer), plainto_tsquery('russian', 'музыкал')) AS rank
FROM test_table
WHERE to_tsvector('russian', title || ' ' || singer) @@ plainto_tsquery('russian', 'музыкал')
   OR SIMILARITY(title, 'музыкал') > 0.3
   OR SIMILARITY(singer, 'музыкал') > 0.3
ORDER BY rank DESC, SIMILARITY(title, 'музыка') DESC, SIMILARITY(singer, 'музыкал') DESC
LIMIT 5;
