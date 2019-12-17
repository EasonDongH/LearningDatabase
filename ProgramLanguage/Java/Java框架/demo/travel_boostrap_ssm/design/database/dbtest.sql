/*
Navicat MySQL Data Transfer

Source Server         : MySQL_Local
Source Server Version : 50540
Source Host           : localhost:3306
Source Database       : dbtest

Target Server Type    : MYSQL
Target Server Version : 50540
File Encoding         : 65001

Date: 2019-12-17 22:14:16
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `money` double(255,0) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account
-- ----------------------------
INSERT INTO `account` VALUES ('13', 'test1575466301910', '1000');
INSERT INTO `account` VALUES ('14', 'test1575466498644', '1000');
INSERT INTO `account` VALUES ('15', 'test1575466756075', '1000');
INSERT INTO `account` VALUES ('16', 'test1575466901836', '1000');
INSERT INTO `account` VALUES ('17', 'test1575466923599', '1000');

-- ----------------------------
-- Table structure for member
-- ----------------------------
DROP TABLE IF EXISTS `member`;
CREATE TABLE `member` (
  `id` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `nickname` varchar(255) DEFAULT NULL,
  `phoneNum` int(11) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of member
-- ----------------------------

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE IF EXISTS `orders`;
CREATE TABLE `orders` (
  `id` int(11) DEFAULT NULL,
  `orderNum` int(11) DEFAULT NULL,
  `orderTime` datetime DEFAULT NULL,
  `orderStatus` varchar(255) DEFAULT NULL,
  `peopleCount` varchar(255) DEFAULT NULL,
  `productId` int(11) DEFAULT NULL,
  `payType` varchar(255) DEFAULT NULL,
  `orderDesc` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of orders
-- ----------------------------
INSERT INTO `orders` VALUES ('1', '12', '2019-12-17 20:47:06', '1', '5', '1', '1', '全家游');
INSERT INTO `orders` VALUES ('2', '23', '2019-12-18 21:14:02', '0', '12', '2', '0', '公司团建');
INSERT INTO `orders` VALUES ('3', '34', '2019-12-22 21:15:02', '1', '2', '2', '2', '个人游');
INSERT INTO `orders` VALUES ('4', '45', '2019-12-17 21:27:26', '0', '2', '3', '1', '亲子游');
INSERT INTO `orders` VALUES ('5', '56', '2019-12-19 21:28:00', '1', '3', '2', '2', '个人游');

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `productNum` varchar(32) DEFAULT NULL,
  `productName` varchar(32) DEFAULT NULL,
  `cityName` varchar(32) DEFAULT NULL,
  `departureTime` datetime DEFAULT NULL,
  `productPrice` double(10,2) DEFAULT NULL,
  `productDesc` varchar(255) DEFAULT NULL,
  `productStatus` tinyint(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of product
-- ----------------------------
INSERT INTO `product` VALUES ('1', 'SB189-8974', '厦门七日游', '厦门', '2020-01-01 08:00:00', '8999.00', '愉快的海边七日游', '1');
INSERT INTO `product` VALUES ('2', 'GN897-258', '重庆三天假', '重庆', '2020-01-15 20:00:00', '6989.00', '火辣的三日狂欢', '0');
INSERT INTO `product` VALUES ('3', 'SZ-2019-0054', '苏州城市小驻', '泰州', '2020-01-15 07:00:00', '1299.00', '这是一个风景如画的城市', '1');
INSERT INTO `product` VALUES ('5', 'HZ-2019-1216', '杭州西湖走一遭', '苏州', '2019-12-20 08:20:00', '888.00', '听说杭州西湖美如画，不如自己走一遭……', '0');
INSERT INTO `product` VALUES ('6', 'WX-2019-1216', '无锡灵山大佛', '无锡', '2019-12-23 10:00:00', '256.00', '虔诚拜佛徒', '1');
INSERT INTO `product` VALUES ('7', 'SH-2019-1216-005', '上海迪斯尼', '上海', '2019-12-20 05:00:00', '2666.00', '中国大陆内第一家迪斯尼乐园', '1');
INSERT INTO `product` VALUES ('8', 'BJ-2019-1216-006', '北京', '扬州', '2019-12-28 05:00:00', '3899.00', '京都走一遭', '0');
INSERT INTO `product` VALUES ('10', '辅导辅导', '苏州城市小驻', '泰州', '2019-12-23 10:00:00', '1299.00', '', '1');

-- ----------------------------
-- Table structure for traveller
-- ----------------------------
DROP TABLE IF EXISTS `traveller`;
CREATE TABLE `traveller` (
  `id` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `sex` varchar(255) DEFAULT NULL,
  `phoneNum` int(11) DEFAULT NULL,
  `credentialsType` varchar(255) DEFAULT NULL,
  `credentialsNum` int(11) DEFAULT NULL,
  `travellerType` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of traveller
-- ----------------------------

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `age` int(11) DEFAULT NULL,
  `gender` varchar(11) DEFAULT NULL,
  `email` varchar(32) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `qq` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `usename` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('23', 'mybatis_testSaveUser', '123456', null, null, null, null, null);
