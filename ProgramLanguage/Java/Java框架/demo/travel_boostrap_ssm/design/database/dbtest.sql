/*
Navicat MySQL Data Transfer

Source Server         : MySQL_Loacl
Source Server Version : 50022
Source Host           : localhost:3306
Source Database       : dbtest

Target Server Type    : MYSQL
Target Server Version : 50022
File Encoding         : 65001

Date: 2019-12-19 16:50:50
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for member
-- ----------------------------
DROP TABLE IF EXISTS `member`;
CREATE TABLE `member` (
  `id` int(11) default NULL,
  `name` varchar(255) default NULL,
  `nickname` varchar(255) default NULL,
  `phoneNum` int(11) default NULL,
  `email` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of member
-- ----------------------------

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE IF EXISTS `orders`;
CREATE TABLE `orders` (
  `id` int(11) default NULL,
  `orderNum` int(11) default NULL,
  `orderTime` datetime default NULL,
  `orderStatus` varchar(255) default NULL,
  `peopleCount` varchar(255) default NULL,
  `productId` int(11) default NULL,
  `payType` varchar(255) default NULL,
  `orderDesc` varchar(255) default NULL
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
-- Table structure for permission
-- ----------------------------
DROP TABLE IF EXISTS `permission`;
CREATE TABLE `permission` (
  `id` varchar(32) NOT NULL,
  `permissionName` varchar(50) default NULL,
  `url` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of permission
-- ----------------------------

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `id` int(11) NOT NULL auto_increment,
  `productNum` varchar(32) default NULL,
  `productName` varchar(32) default NULL,
  `cityName` varchar(32) default NULL,
  `departureTime` datetime default NULL,
  `productPrice` double(10,2) default NULL,
  `productDesc` varchar(255) default NULL,
  `productStatus` tinyint(255) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role` (
  `id` varchar(32) NOT NULL,
  `roleName` varchar(50) default NULL,
  `roleDesc` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES ('1', 'ROLE_USER', 'test');

-- ----------------------------
-- Table structure for role_permission
-- ----------------------------
DROP TABLE IF EXISTS `role_permission`;
CREATE TABLE `role_permission` (
  `permissionId` varchar(32) NOT NULL default '',
  `roleId` varchar(32) NOT NULL default '',
  PRIMARY KEY  (`permissionId`,`roleId`),
  KEY `roleId` (`roleId`),
  CONSTRAINT `role_permission_ibfk_1` FOREIGN KEY (`permissionId`) REFERENCES `permission` (`id`),
  CONSTRAINT `role_permission_ibfk_2` FOREIGN KEY (`roleId`) REFERENCES `role` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of role_permission
-- ----------------------------

-- ----------------------------
-- Table structure for traveller
-- ----------------------------
DROP TABLE IF EXISTS `traveller`;
CREATE TABLE `traveller` (
  `id` int(11) default NULL,
  `name` varchar(255) default NULL,
  `sex` varchar(255) default NULL,
  `phoneNum` int(11) default NULL,
  `credentialsType` varchar(255) default NULL,
  `credentialsNum` int(11) default NULL,
  `travellerType` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of traveller
-- ----------------------------

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` varchar(32) NOT NULL,
  `email` varchar(50) NOT NULL,
  `username` varchar(50) default NULL,
  `PASSWORD` varchar(50) default NULL,
  `phoneNum` varchar(20) default NULL,
  `STATUS` int(11) default NULL,
  PRIMARY KEY  (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('1', 'test', 'test', 'test', 'test', '0');

-- ----------------------------
-- Table structure for users_role
-- ----------------------------
DROP TABLE IF EXISTS `users_role`;
CREATE TABLE `users_role` (
  `userId` varchar(32) NOT NULL default '',
  `roleId` varchar(32) NOT NULL default '',
  PRIMARY KEY  (`userId`,`roleId`),
  KEY `roleId` (`roleId`),
  CONSTRAINT `users_role_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`id`),
  CONSTRAINT `users_role_ibfk_2` FOREIGN KEY (`roleId`) REFERENCES `role` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users_role
-- ----------------------------
INSERT INTO `users_role` VALUES ('1', '1');
