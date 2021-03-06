-- CREATE TABLE users (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(20) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     password VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );


-- CREATE TABLE libraries (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     public VARCHAR (5),
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE books (
--     id int NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     author VARCHAR(255) NOT NULL,
--     genre VARCHAR(255),
--     synopsis VARCHAR(255),
--     cover VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     views int,
--     libraries int,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- ALTER TABLE libraries
-- MODIFY COLUMN public VARCHAR(5);

-- INSERT INTO books(
--         title, 
--         author,
--         genre,
--         synopsis,
--         cover,
--         userId
--     ) VALUES(
--        "Ready Player One",
--        "Ernest Cline",
--        "Sci-Fi",
--        "Wade Watts takes on the Sixers as he strives to find the fated Easter Egg in the Oasis.",
--         "https://images.gr-assets.com/books/1500930947l/9969571.jpg",
--         "9a3d3bc0-a91d-4879-a0cd-72c142659264")

-- INSERT INTO libraries(
--             name,
--             description,
--             userId
--             ) VALUES(
--            "Summer Reading",
--             "All the great books to read this summer!",
--             "9a3d3bc0-a91d-4879-a0cd-72c142659264"
--             )

-- CREATE TABLE librarybooks (
--     id int NOT NULL AUTO_INCREMENT,
--     libraryId int NOT NULL,
--     bookId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (libraryId, bookId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (libraryId)
--         REFERENCES libraries(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (bookId)
--         REFERENCES books(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM librarybooks lb
-- INNER JOIN  books b ON b.id = lb.bookId 
-- WHERE (libraryId = 2)

-- SELECT * FROM users
-- SELECT * FROM books
-- SELECT * FROM libraries 
-- SELECT * FROM librarybooks

-- DELETE FROM libraries

    -- UPDATE  books
    -- SET views = views + 1
    -- WHERE id = 2

-- DELETE FROM librarybooks 
-- WHERE bookId = 3
-- AND libraryId = 19