CREATE TABLE GAME (
	CHAMPION_ID INT,
	SUMMONER_ID BIGINT,
	CREATE_DATE BIGINT,
	GAME_ID BIGINT,
	GAME_MODE VARCHAR(50),
	GAME_TYPE VARCHAR(50),
	INVALID BOOLEAN,
	IP_EARNED INT,
	LEVEL INT,
	MAP_ID INT,
	SPELL1 INT,
	SPELL2 INT,
	SUB_TYPE VARCHAR(50),
	TEAM_ID INT,
	PRIMARY KEY(GAME_ID)
);

CREATE TABLE PLAYER (
	GAME_ID VARCHAR(50) NOT NULL,
	CHAMPION_ID INT NOT NULL,
	SUMMONER_ID VARCHAR(50) NOT NULL,
	TEAM_ID BIGINT NOT NULL,
	PRIMARY KEY(GAME_ID, SUMMONER_ID),
	CONSTRAINT fk_game_id
		FOREIGN KEY (GAME_ID)
		REFERENCES GAME(GAME_ID)
);

CREATE TABLE SUMMONER (
	ID BIGINT,
	NAME VARCHAR(50),
	PROFILE_ICON_ID INT,
	REVISION_DATE BIGINT,
	PRIMARY KEY(ID)
);

CREATE TABLE RAW_STATS (
	GAME_ID VARCHAR(50),
	ASSISTS INT,
	BARRACKS_KILLED INT,
	CHAMPIONS_KILLED INT,
	COMBAT_PLAYER_SCORE INT,
	CONSUMABLES_PURCHASED INT,
	DAMAGE_DEALT_PLAYER INT,
	DOUBLE_KILLS INT,
	FIRST_BLOOD INT,
	GOLD INT,
	GOLD_EARNED INT,
	GOLD_SPENT INT,
	ITEM0 INT,
	ITEM1 INT,
	ITEM2 INT,
	ITEM3 INT,
	ITEM4 INT,
	ITEM5 INT,
	ITEM6 INT,
	ITEMS_PURCHASED INT,
	KILLING_SPREES INT,
	LARGEST_CRITICAL_STRIKE INT,
	LARGEST_KILLING_SPREE INT,
	LARGEST_MULTI_KILL INT,
	LEGENDARY_ITEMS_CREATED INT,
	LEVEL INT,
	MAGIC_DAMAGE_DEALT_PLAYER INT,
	MAGIC_DAMAGE_DEALT_TO_CHAMPIONS INT,
	MAGIC_DAMAGE_TAKEN INT,
	MINIONS_DENIED INT,
	MINIONS_KILLED INT,
	NEUTRAL_MINIONS_KILLED INT,
	NEUTRAL_MINIONS_KILLED_ENEMY_JUNGLE INT,
	NEUTRAL_MINIONS_KILLED_YOUR_JUNGLE INT,
	NEXUS_KILLED BOOLEAN,
	NODE_CAPTURE INT,
	NODE_CAPTURE_ASSIST INT,
	NODE_NEUTRALIZE INT,
	NODE_NEUTRALIZE_ASSIST INT,
	NUM_DEATHS INT,
	NUM_ITEMS_BOUGHT INT,
	OBJECTIVE_PLAYER_SCORE INT,
	PENTA_KILLS INT,
	PHYSICAL_DAMAGE_DEALT_PLAYER INT,
	PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS INT,
	PHYSICAL_DAMAGE_TAKEN INT,
	QUADRA_KILLS INT,
	SIGHT_WARDS_BOUGHT INT,
	SPELL1_CAST INT,
	SPELL2_CAST INT,
	SPELL3_CAST INT,
	SPELL4_CAST INT,
	SUMMON_SPELL1_CAST INT,
	SUMMON_SPELL2_CAST INT,
	SUPER_MONSTER_KILLED INT,
	TEAM INT,
	TEAM_OBJECTIVE INT,
	TIME_PLAYED INT,
	TOTAL_DAMAGE_DEALT INT,
	TOTAL_DAMAGE_DEALT_TO_CHAMPIONS INT,
	TOTAL_DAMAGE_TAKEN INT,
	TOTAL_HEAL INT,
	TOTAL_PLAYER_SCORE INT,
	TOTAL_SCORE_RANK INT,
	TOTAL_TIME_CROWD_CONTROL_DEALT INT,
	TOTAL_UNITS_HEALED INT,
	TRIPLE_KILLS INT,
	TRUE_DAMAGE_DEALT_PLAYER INT,
	TRUE_DAMAGE_DEALT_TO_CHAMPIONS INT,
	TRUE_DAMAGE_TAKEN INT,
	TURRETS_KILLED INT,
	UNREAL_KILLS INT,
	VICTORY_POINT_TOTAL INT,
	VISION_WARDS_BOUGHT INT,
	WARD_KILLED INT,
	WARD_PLACED INT,
	WIN BOOLEAN,
	PRIMARY KEY(GAME_ID),
	CONSTRAINT fk_game_id
		FOREIGN KEY (GAME_ID)
		REFERENCES GAME(GAME_ID)
);

CREATE TABLE PARTICIPANT (
    MATCH_ID BIGINT,
    CHAMPION_ID INTEGER,
    HIGHEST_ACHIEVED_SEASON_TIER VARCHAR(50),
    PARTICIPANT_ID BIGINT,
    SPELL1_ID INTEGER,
    SPELL2_ID INTEGER,
    TEAM_ID INTEGER,
    LANE VARCHAR(50),
    ROLE VARCHAR(50),
	PRIMARY KEY(PARTICIPANT_ID, MATCH_ID),
	CONSTRAINT fk_participant_match_id
		FOREIGN KEY (MATCH_ID)
		REFERENCES RANKED_GAME(MATCH_ID)
);

CREATE TABLE PARTICIPANT_TIMELINE_DATA (
	MATCH_ID BIGINT,
	PARTICIPANT_ID BIGINT,
	NAME VARCHAR(100),
	ZERO_TO_TEN FLOAT,
	TEN_TO_TWENTY FLOAT,
	TWENTY_TO_THIRTY FLOAT,
	THIRTY_TO_END FLOAT,
	PRIMARY KEY(MATCH_ID, PARTICIPANT_ID, NAME),
	CONSTRAINT fk_timeline_participant_id
		FOREIGN KEY (MATCH_ID, PARTICIPANT_ID)
		REFERENCES PARTICIPANT(MATCH_ID, PARTICIPANT_ID)
);

CREATE TABLE PARTICIPANT_STATS (
	MATCH_ID BIGINT,
	PARTICIPANT_ID BIGINT, 
	ASSISTS BIGINT, 
	CHAMP_LEVEL BIGINT, 
	COMBAT_PLAYER_SCORE BIGINT, 
	DEATHS BIGINT, 
	DOUBLE_KILLS BIGINT, 
	FIRST_BLOOD_ASSIST BOOLEAN, 
	FIRST_BLOOD_KILL BOOLEAN, 
	FIRST_INHIBITOR_ASSIST BOOLEAN, 
	FIRST_INHIBITOR_KILL BOOLEAN, 
	FIRST_TOWER_ASSIST BOOLEAN, 
	FIRST_TOWER_KILL BOOLEAN, 
	GOLD_EARNED BIGINT, 
	GOLD_SPENT BIGINT, 
	INHIBITOR_KILLS BIGINT, 
	ITEM0 BIGINT, 
	ITEM1 BIGINT, 
	ITEM2 BIGINT, 
	ITEM3 BIGINT, 
	ITEM4 BIGINT, 
	ITEM5 BIGINT, 
	ITEM6 BIGINT, 
	KILLING_SPREES BIGINT, 
	KILLS BIGINT, 
	LARGEST_CRITICAL_STRIKE BIGINT, 
	LARGEST_KILLING_SPREE BIGINT, 
	LARGEST_MULTI_KILL BIGINT, 
	MAGIC_DAMAGE_DEALT BIGINT, 
	MAGIC_DAMAGE_DEALT_TO_CHAMPIONS BIGINT, 
	MAGIC_DAMAGE_TAKEN BIGINT, 
	MINIONS_KILLED BIGINT, 
	NEUTRAL_MINIONS_KILLED BIGINT, 
	NEUTRAL_MINIONS_KILLED_ENEMY_JUNGLE BIGINT, 
	NEUTRAL_MINIONS_KILLED_TEAM_JUNGLE BIGINT, 
	NODE_CAPTURE BIGINT, 
	NODE_CAPTURE_ASSIST BIGINT, 
	NODE_NEUTRALIZE BIGINT, 
	NODE_NEUTRALIZE_ASSIST BIGINT, 
	OBJECTIVE_PLAYER_SCORE BIGINT, 
	PENTA_KILLS BIGINT, 
	PHYSICAL_DAMAGE_DEALT BIGINT, 
	PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS BIGINT, 
	PHYSICAL_DAMAGE_TAKEN BIGINT, 
	QUADRA_KILLS BIGINT, 
	SIGHT_WARDS_BOUGHT_IN_GAME BIGINT, 
	TEAM_OBJECTIVE BIGINT, 
	TOTAL_DAMAGE_DEALT BIGINT, 
	TOTAL_DAMAGE_DEALT_TO_CHAMPIONS BIGINT, 
	TOTAL_DAMAGE_TAKEN BIGINT, 
	TOTAL_HEAL BIGINT, 
	TOTAL_PLAYER_SCORE BIGINT, 
	TOTAL_SCORE_RANK BIGINT, 
	TOTAL_TIME_CROWD_CONTROL_DEALT BIGINT, 
	TOTAL_UNITS_HEALED BIGINT, 
	TOWER_KILLS BIGINT, 
	TRIPLE_KILLS BIGINT, 
	TRUE_DAMAGE_DEALT BIGINT, 
	TRUE_DAMAGE_DEALT_TO_CHAMPIONS BIGINT, 
	TRUE_DAMAGE_TAKEN BIGINT, 
	UNREAL_KILLS BIGINT, 
	VISION_WARDS_BOUGHT_IN_GAME BIGINT, 
	WARDS_KILLED BIGINT, 
	WARDS_PLACED BIGINT, 
	WINNER BOOLEAN, 
	PRIMARY KEY(MATCH_ID, PARTICIPANT_ID), 
	CONSTRAINT fk_participant_id
		FOREIGN KEY (MATCH_ID, PARTICIPANT_ID)
		REFERENCES PARTICIPANT(MATCH_ID, PARTICIPANT_ID)
);

CREATE TABLE RANKED_GAME (
	MAP_ID INT, 
	MATCH_CREATION BIGINT, 
	MATCH_DURATION BIGINT, 
	MATCH_ID BIGINT, 
	MATCH_MODE VARCHAR(50), 
	MATCH_TYPE VARCHAR(50), 
	MATCH_VERSION VARCHAR(50), 
	PLATFORM_ID VARCHAR(50), 
	QUEUE_TYPE VARCHAR(50), 
	REGION VARCHAR(50), 
	SEASON VARCHAR(50), 
	PRIMARY KEY(MATCH_ID)
);

