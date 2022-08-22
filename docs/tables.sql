CREATE TABLE Users(
   id       SERIAL  NOT NULL PRIMARY KEY 
  ,name     VARCHAR(150) NOT NULL
  ,username VARCHAR(100) NOT NULL
  ,email    VARCHAR(200) NOT NULL
  ,phone    VARCHAR(100)
  ,website  VARCHAR(200)
);