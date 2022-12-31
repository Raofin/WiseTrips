-- Switch to the master database to create a new database
USE master;

-- Create a new database named WiseTrips
CREATE DATABASE WiseTrips;
GO

-- Switch to the newly created database
USE WiseTrips;
GO

CREATE TABLE Agencies (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	Name varchar(50) NOT NULL,
	IsInternational bit NOT NULL,
	UserId int NOT NULL
)

CREATE TABLE Coupons (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	Code varchar(50) NOT NULL,
	Discount int NOT NULL,
	AddedBy int NOT NULL,
	SponsoredBy int NULL,
	ExpireOn datetime NOT NULL
)

CREATE TABLE Hotels (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	Name varchar(50) NOT NULL,
	Description text NOT NULL,
	Star int NOT NULL,
	Price int NOT NULL
)

CREATE TABLE Logs (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	UserId int NULL,
	Action varchar(20) NOT NULL,
	OldUsername varchar(50) NULL,
	OldEmail varchar(50) NULL,
	OldPassword varchar(50) NULL,
	NewUsername varchar(50) NULL,
	NewEmail varchar(50) NULL,
	NewPassword varchar(50) NULL,
	DateTime datetime NOT NULL
)

CREATE TABLE Packages (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	Name varchar(50) NOT NULL,
	AgencyId int NOT NULL,
	Country varchar(50) NOT NULL,
	Details text NOT NULL,
	Duration int NOT NULL,
	Price int NOT NULL
)

CREATE TABLE Roles (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	Name varchar(50) NOT NULL,
	AddedOn datetime NOT NULL,
	UserId int NOT NULL
)

CREATE TABLE Tokens (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	AuthToken varchar(128) NOT NULL,
	CreatedOn datetime NOT NULL,
	ExpiredOn datetime NOT NULL,
	UserId int NOT NULL
)

CREATE TABLE Trips (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	UserId int NOT NULL,
	PackageId int NOT NULL,
	HotelId int NOT NULL,
	Persons int NOT NULL,
	Date datetime NOT NULL,
	UsedCoupon int NULL,
	Paid int NOT NULL
)

CREATE TABLE Users (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	Username varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	Sex varchar(50) NOT NULL,
	Spent int NOT NULL,
	RegisteredOn datetime NOT NULL,
	AccountStatus bit NULL
)

INSERT INTO Agencies (Name, IsInternational, UserId) 
VALUES ('Sunshine Travels', 1, 5),
       ('The Royal Seat', 1, 4),
       ('Eagle Tours', 0, 1)
       
INSERT INTO Coupons (Code, Discount, AddedBy, SponsoredBy, ExpireOn) 
VALUES ('PEACOCKTRIP', 5, 4, 1, CAST('2023-06-09' AS DateTime)),
       ('SINGLESDAY', 7, 4, 1, CAST('2023-12-01' AS DateTime))

INSERT INTO Hotels (Name, Description, Star, Price) 
VALUES ('Sandman Longueuil', 'The Sandman Longueuil hotel has easy access to many of the city’s top attractions, including the Casino, Old Montreal, La Ronde and Montreal’s underground city. Cozy guest rooms with panoramic views allow you to unwind, and an indoor pool and sauna ensure that your stay is filled with ease. Whether you’re on the go, or in town to check out all the charming sights and sounds, Sandman Longueuil is always an impressive treat.', 3, 16000),
       ('WelcomINNS', 'Minutes away from the heart of downtown Ottawa, the 109 room WelcomINNS Ottawa offers comfort and convenience at an affordable price. The WelcomINNS Ottawa is perfectly situated off the Trans-Canada Highway, across the street from the St. Laurent Shopping Centre and in close proximity to top tourist destinations, including the Canada Science and Technology Museum, the National Gallery of Canada, and Parliament Hill. As a guest, your comfort and satisfaction are our top priority. For this reason, we provide complimentary parking, Wi-Fi, and continental breakfast. We also offer an onsite fitness facility available 24/7.', 4, 23000),
       ('Holiday Inn Québec', 'Nestled in charming Sainte-Foy, the heart of culturally rich Québec City is within easy reach of the Holiday Inn Québec. We’ve got a whole buffet full of offerings ready to help kickstart your day. We also have Wi-Fi, coffee and tea, and all the in-room conveniences that make you feel right at home, even when you’re away.', 4, 21000),
       ('Hotel Palace Royal ', 'A little stroll down Rue St-Jean, about 150 meters from the fortified walls, you will find an oasis in the heart of Old Québec, Hotel Palace Royal. This majestic building is in perfect harmony with the European character of Québec!', 3, 15000),
       ('Hotel Ibis La Défense Centre', 'In the heart of the La Défense business district, the ibis Paris La Défense Centre hotel is ideally situated between the Grande Arche and the Arc de Triomphe. The hotel boasts a restaurant, bar and 286 air-conditioned rooms with free Wi-Fi access. The nearby Esplanade de la Défense metro station (line 1), provides easy access to the Porte Maillot convention center, the Champs Elysées and even the 4 Temps shopping mall within 10 minutes.', 5, 35000),
       ('Ibis Paris Berthier', 'The Hotel Ibis Paris Berthier is situated in the 17th arrondissement in the north of Paris, close to the Champs-Élysées and the Eiffel Tower. It has 688 rooms with air-conditioning and free Wi-Fi, a restaurant and conference facilities. The nearest metro is Porte de Clichy.', 5, 32000),
       ('Villa Luxembourg', 'Just a 5-minute walk from the Luxembourg Gardens, Villa Luxembourg is in a great location for exploring Paris. Villa Luxembourg feature a minibar, a refrigerator and a microwave. Each has a private bathroom with a bathtub and a hairdryer. A kitchenette is available in the rooms and kitchenware is provided for an additional fee. The hotel serves a buffet breakfast daily and room service is also available. Other facilities include dry cleaning and a ticket booking service. Wi-Fi is available in rooms upon demand. A 2-minute walk from Vavin Metro Station, Saint-Germain-Des-Près and Ile de la Cité can be accessed directly.', 5, 40000),
       ('Kyriad Nice Port', 'This hotel sits in central Nice, just 1,150 feet from the ferry port and a 20-minute walk from the Promenade des Anglais. Its rooms are air-conditioned with free Wi-Fi access. The guest rooms at the Kyriad Nice Port are equipped with flat-screen TVs with satellite channels and a private bathroom. Each is serviced by a lift. The Kyriad Hotel Nice Port has a 24-hour reception, which is hosted by a multilingual team. The hotel serves a buffet breakfast every morning.', 3, 10000),
       ('Comfort Hotel Lichtenberg', 'The Comfort Hotel Lichtenberg is located in the northeast part of Berlin, opposite the Die Pyramide building, featuring the highest clock in Europe. The hotel offers 120 comfortably furnished guest rooms. All rooms have cable TV and wireless internet access. All standard guest rooms are equipped with private bathrooms, hair dryers, spacious work desks, direct-dial telephones and satellite television. This is a non-smoking hotel. The distinguishing mark of the Comfort Hotel Lichtenberg is to be able to stay overnight at reasonable rates. For an excellent lodging experience, we cordially invite you to stay with us the next time you are in Berlin.', 3, 15000),
       ('Springfield Hotel', 'The Springfield Hotel is just a 15-minute drive from Dublin’s center, located in the center of Leixlip. We offer gym, free parking, and a modern restaurant serving hearty cuisine. A regular Airport Hopper Bus service is available. Each bright modern room at The Springfield Hotel includes a private bathroom and hairdryer. Free tea and coffee is provided in each room, along with flat-screen cable TV and free Wi-Fi.', 5, 36900)

INSERT INTO Packages (Name, AgencyId, Country, Details, Duration, Price)
VALUES
    ('Cox''s Bazar Trip', 1, 'Bangladesh', 'Hotel The Cox Today is one of the best five-star standard luxury hotel in Cox''s Bazar. It''s magnificent and uniquely located along the world''s longest natural beach in Cox''s Bazar and 10 minutes drive from The Airport. The comforts and charms of the architectural magnanimity complement the natural beauty and wonder of the Tourist destination of Cox''s Bazar. It''s an oasis which reflects contemporary style of living. We are committed to provide the guest with world class hospitality within affordable price.', 4, 200),
    ('Taste of Europe Tour', 3, 'Germany', 'The 15-day taste of Europe Tour will take you to the heart of nine uniquely beautiful European countries: France, Luxembourg, Germany, Netherlands, Belgium, Switzerland, Italy, Monaco and Vatican City. This tour is a perfect introduction to Europe, ideal for first timers and those who want to explore and experience as much as possible in 15 days. You''ll start your journey enjoying the breathtaking mountain scenery of Switzerland before heading south into Italy, where you will have the opportunity to experience hundreds of years of tradition and culture. Discover the glamorous French Riviera and return to Paris to conclude your tour and be part of a truly memorable journey.', 15, 32000),
    ('Explore Switzerland in 07 Days', 2, 'Switzerland', 'The 07-day taste of Europe Tour will take you to the heart of beautiful European country: Switzerland. This tour is a perfect introduction to Europe, ideal for first timers and those who want to explore and experience as much as possible in 07 days. You''ll start your journey enjoying the breathtaking mountain scenery of Zurich before heading south into Geneva, where you will have the opportunity to experience hundreds of years of tradition and culture. Discover the glamorous Mount Titlis and transfer to Geneva to conclude your tour and be part of a truly memorable journey.', 7, 18000),
    ('Explore China in 07 Days', 2, 'China', 'The 07-days taste of China tour will take you to the heart of beautiful Asian country: China. This tour is a perfect introduction to Asia, ideal for first timers and those who want to explore and experience as much as possible in 07 days. You''ll start your journey enjoying the breathtaking scenery of Beijing, where you will have the opportunity to experience hundreds of years of tradition and culture of Shanghai. Discover the amazing traditional life of Shanghai and next day transfer to Airport to conclude your tour and be part of a truly memorable journey.', 7, 15000),
    ('Explore Greece in 07 Days', 1, 'Greece', 'The 07-day taste of Greece Tour will take you to the heart of two uniquely beautiful destinations: Athens and Santorini. This tour is a perfect introduction to Greece, ideal for first timers and those who want to explore and experience as much as possible in 07 days. You''ll start your journey enjoying the breathtaking scenery of Athens where you will have the opportunity to experience hundreds of years of tradition and culture. Discover the Piraeus, Beach Riviera, Cape Sounio, Delphi, Hydra, Poros, Egina and Santorini and conclude your tour and be part of a truly memorable journey.', 7, 23000),
    ('Nairobi City Breaks in 05 Days', 3, 'Kenya', 'The 05-day taste of Kenya Tour will take you to the heart of five uniquely beautiful African destinations: Nairobi. This tour is a perfect introduction to Africa, ideal for first timers and those who want to explore and experience as much as possible in 05 days. You''ll start your journey enjoying the breathtaking scenery of Nairobi before heading north into Maasai Mara, where you will have the opportunity to experience hundreds of years of tradition and culture. Discover the glamorous Nairobi and Maasai Mara to conclude your tour and be part of a truly memorable journey.', 5, 4200),
    ('Umrah', 2, 'Saudi Arabia', 'Jetway Hajj Umrah group put special focus while arranging 5-star facilities for your Umrah package 2022-2023 from Dhaka, Bangladesh. Jetway Umrah packages are carefully crafted for families with kids and senior citizens. Luxury to economy Umrah Hajj packages from Bangladesh for 7 days, 10 days, or 14 days duration with fast processing of Umrah Visa, everything we have at competitive cost. Umrah visa fee includes health insurance. 5-star hotels located adjacent to Al-Haram and other hotels also nearby.', 10, 16000),
    ('Remarkable West Coast', 1, 'USA', 'The 07-days taste of America Tour will take you to the heart of three uniquely beautiful cities: Los Angeles, Las Vegas and San Francisco. This tour is a perfect introduction to the USA, ideal for first timers and those who want to explore and experience as much as possible in 07 days. You''ll start your journey enjoying the breathtaking scenery of Los Angeles before heading south into Las Vegas, where you will have the opportunity to experience hundreds of years of tradition and culture. Discover the glamorous San Francisco city tour and return with a memorable journey.', 7, 20000)

INSERT INTO Roles (Name, AddedOn, UserId)
VALUES
    ('Tourist', '2022-12-07 04:28:00.000', 1),
    ('Tourist', '2022-12-07 04:28:00.000', 2),
    ('Tourist', '2022-12-07 04:28:00.000', 3),
    ('Admin', '2022-12-07 04:29:00.000', 4),
    ('Agency', '2022-12-07 04:29:00.000', 5),
    ('Tourist', '2022-12-07 04:31:00.000', 4),
    ('Agency', '2022-12-07 04:35:00.000', 4),
    ('Admin', '2022-12-07 04:35:00.000', 1),
    ('Agency', '2022-12-07 04:41:35.607', 1)

INSERT INTO Trips (UserId, PackageId, HotelId, Persons, Date, UsedCoupon, Paid)
VALUES
    (1, 1, 2, 3, '2022-12-11 02:00:23.797', NULL, 23013),
    (2, 3, 4, 2, '2022-12-11 02:04:44.500', 1, 12648),
    (3, 4, 5, 4, '2022-12-11 02:25:52.620', NULL, 22420)

INSERT INTO Users (Username, Email, Password, Sex, Spent, RegisteredOn, AccountStatus)
VALUES
    ('Raofin', '20-42459-1@student.aiub.edu', '1111', 'male', 23013, '2022-12-07 04:13:00.000', 1),
    ('Sijan', '19-39587-1@student.aiub.edu', 'f3eQ', 'male', 12648, '2022-12-07 04:15:00.000', 1),
    ('Prottush', '19-41272-3@student.aiub.edu', 'fnW2', 'male', 22420, '2022-12-07 04:16:00.000', 1),
    ('Admin', 'admin@wisetrips.com', 'admin', 'male', 0, '2022-12-07 04:19:00.000', 1),
    ('Johnnie', 'johnnie@email.com', '2ahD', 'male', 0, '2022-12-07 04:27:00.000', 1)

ALTER TABLE Logs ADD CONSTRAINT DF_Log_DateTime DEFAULT (GETDATE()) FOR DateTime
ALTER TABLE Roles ADD CONSTRAINT DF_Roles_Added DEFAULT (GETDATE()) FOR AddedOn
ALTER TABLE Tokens ADD CONSTRAINT DF_Tokens_Created DEFAULT (GETDATE()) FOR CreatedOn
ALTER TABLE Trips ADD CONSTRAINT DF_Histories_Date DEFAULT (GETDATE()) FOR Date
ALTER TABLE Users ADD CONSTRAINT DF_Users_Spent DEFAULT (0) FOR Spent
ALTER TABLE Users ADD CONSTRAINT DF_Users_Registered DEFAULT (GETDATE()) FOR RegisteredOn

ALTER TABLE Agencies ADD CONSTRAINT FK_Agencies_Users FOREIGN KEY(UserId) REFERENCES Users (Id) ON DELETE CASCADE
ALTER TABLE Coupons ADD CONSTRAINT FK_Coupons_Agencies FOREIGN KEY(SponsoredBy) REFERENCES Agencies (Id)
ALTER TABLE Coupons ADD CONSTRAINT FK_Coupons_Users FOREIGN KEY(AddedBy) REFERENCES Users (Id) ON DELETE CASCADE
ALTER TABLE Logs ADD CONSTRAINT FK_Logs_Users FOREIGN KEY(UserId) REFERENCES Users (Id) ON DELETE CASCADE
ALTER TABLE Packages ADD CONSTRAINT FK_Packages_Agencies FOREIGN KEY(AgencyId) REFERENCES Agencies (Id)
ALTER TABLE Roles ADD CONSTRAINT FK_Roles_Users FOREIGN KEY(UserId) REFERENCES Users (Id) ON DELETE CASCADE
ALTER TABLE Tokens ADD CONSTRAINT FK_Tokens_Users FOREIGN KEY(UserId) REFERENCES Users (Id) ON DELETE CASCADE
ALTER TABLE Trips ADD CONSTRAINT FK_Histories_Coupons FOREIGN KEY(UsedCoupon) REFERENCES Coupons (Id)
ALTER TABLE Trips ADD CONSTRAINT FK_Histories_Packages FOREIGN KEY(PackageId) REFERENCES Packages (Id)
ALTER TABLE Trips ADD CONSTRAINT FK_Histories_Users FOREIGN KEY(UserId) REFERENCES Users (Id) ON DELETE CASCADE
ALTER TABLE Trips ADD CONSTRAINT FK_Trips_Hotels FOREIGN KEY(HotelId) REFERENCES Hotels (Id)