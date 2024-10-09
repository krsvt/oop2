CREATE EXTENSION IF NOT EXISTS pg_trgm;  -- Для триграммного поиска
CREATE EXTENSION IF NOT EXISTS unaccent;  -- Для удаления акцентов (по желанию, если нужно)

-- Создаем индексы для артистов
CREATE INDEX idx_artist_fulltext_search ON artist
USING GIN (to_tsvector('russian', name));

CREATE INDEX idx_artist_trgm ON artist
USING GIN (name gin_trgm_ops);

-- Создаем индексы для альбомов
CREATE INDEX idx_album_fulltext_search ON album
USING GIN (to_tsvector('russian', title));

CREATE INDEX idx_album_trgm ON album
USING GIN (title gin_trgm_ops);

CREATE OR REPLACE FUNCTION SearchByArtist(query TEXT)
RETURNS TABLE(artist_id INT, artist_name TEXT) AS $$
BEGIN
    IF LENGTH(query) < 2 THEN
        RETURN QUERY SELECT id, name FROM artist; -- Возвращаем всех, если строка слишком короткая
    END IF;

    RETURN QUERY
    SELECT a.id, a.name
    FROM artist a
    WHERE to_tsvector('russian', a.name) @@ plainto_tsquery('russian', query)
       OR SIMILARITY(a.name, query) > 0.3
       OR a.name ILIKE '%' || query || '%'  -- Позволяет выполнять частичный поиск
    ORDER BY ts_rank(to_tsvector('russian', a.name), plainto_tsquery('russian', query)) DESC,
             SIMILARITY(a.name, query) DESC
    LIMIT 5;
END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION SearchByAlbumsAndSongsCollections(query TEXT)
RETURNS TABLE(id INT, title TEXT, type TEXT) AS $$
BEGIN
    RETURN QUERY
    SELECT a.id AS id, a.title AS title, 'album' AS type
    FROM album a
    WHERE to_tsvector('russian', a.title) @@ plainto_tsquery('russian', query) -- Поиск по альбомам
       OR SIMILARITY(a.title, query) > 0.3 -- Сравнение по триграммам для альбомов

    UNION ALL

    SELECT sc.id AS id, sc.title AS title, 'songs_collection' AS type
    FROM songs_collection sc
    WHERE to_tsvector('russian', sc.title) @@ plainto_tsquery('russian', query) -- Поиск по названиям коллекций
       OR SIMILARITY(sc.title, query) > 0.3 -- Сравнение по триграммам для коллекций

    ORDER BY title -- Сортировка результатов по названию
    LIMIT 5; -- Лимитируем количество результатов
END;
$$ LANGUAGE plpgsql;
