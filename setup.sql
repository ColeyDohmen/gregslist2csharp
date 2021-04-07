USE gregslistcoley;

CREATE TABLE cars
(
    id INT AUTO_INCREMENT,
    make VARCHAR(255) NOT NULL UNIQUE,
    model VARCHAR(255),
    year INT,
    color VARCHAR(255),

    PRIMARY KEY (id)

);

INSERT INTO cars
(make, model, year, color)
VALUES
("subie", "forester", 2010, "teal")

Get All of a collection
SELECT * FROM cars;