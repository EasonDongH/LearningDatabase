/*
Navicat MySQL Data Transfer

Source Server         : MySQL_Local
Source Server Version : 50540
Source Host           : localhost:3306
Source Database       : dbtest

Target Server Type    : MYSQL
Target Server Version : 50540
File Encoding         : 65001

Date: 2019-12-16 22:19:57
*/

SET FOREIGN_KEY_CHECKS=0;

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
