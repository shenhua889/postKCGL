/*
Navicat MySQL Data Transfer

Source Server         : 10.138.4.66
Source Server Version : 50514
Source Host           : 10.138.4.66:3306
Source Database       : stamp

Target Server Type    : MYSQL
Target Server Version : 50514
File Encoding         : 65001

Date: 2017-12-15 16:19:49
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `inload`
-- ----------------------------
DROP TABLE IF EXISTS `inload`;
CREATE TABLE `inload` (
  `RC` int(10) NOT NULL AUTO_INCREMENT,
  `In_stock_ID` int(10) DEFAULT NULL,
  `in_stock_Name` varchar(80) DEFAULT NULL,
  `Date` varchar(20) DEFAULT NULL,
  `Amount` int(10) DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `cost_price` decimal(10,0) DEFAULT NULL,
  `source` varchar(80) DEFAULT NULL,
  `source_RC` int(10) DEFAULT NULL COMMENT '同一个来源，递增，年底清空',
  `Remark` varchar(80) DEFAULT NULL,
  `FLAG` int(1) DEFAULT NULL,
  PRIMARY KEY (`RC`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of inload
-- ----------------------------
INSERT INTO `inload` VALUES ('1', '2', '1', '2017年12月5日', '11', '11', '11', '1', '11', '111', '0');
INSERT INTO `inload` VALUES ('2', '108', '222', '2017年12月5日', '2', '2', '2', '1111', '1', '2', '0');
INSERT INTO `inload` VALUES ('3', '109', '测试数据', '2017年12月5日', '10', '30', '20', '省邮电', '1', '测试备注', '0');
INSERT INTO `inload` VALUES ('4', '110', '123123', '2017年12月5日', '123', '123', '123', '1111', '1', '123', '0');

-- ----------------------------
-- Table structure for `in_stock`
-- ----------------------------
DROP TABLE IF EXISTS `in_stock`;
CREATE TABLE `in_stock` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(80) DEFAULT NULL,
  `amount` int(10) DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `cost_price` decimal(10,0) DEFAULT NULL,
  `Address` varchar(80) DEFAULT NULL,
  `Flag` int(1) DEFAULT NULL COMMENT '0为存在，1为删除',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of in_stock
-- ----------------------------
INSERT INTO `in_stock` VALUES ('2', '[杭州邮政]《美丽西溪 人文桃源》珍藏明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('3', '[杭州邮政]【预售】浙江大学120周年校庆珍藏记事本', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('4', '[杭州邮政]2016超级旅游护照家庭版', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('5', '[杭州邮政]西湖三十景明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('6', '《2016“灵猴献瑞 马到成功”丝绢荧光明信片》珍藏折', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('7', '《十二生肖之鸡年酉福》贺岁套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('8', '【180元门票区】2017年4月29日卢鑫玉浩相声专场杭州站', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('9', '【280元专区】【五一特惠280元*2张】2017年4月29日卢鑫玉浩相声专场杭州站', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('10', '【80元门票区】2017年4月29日卢鑫玉浩相声专场杭州站', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('11', '【杭州邮政】（9月中旬到货）《盛世峰会·韵味杭州》纪念珍藏册', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('12', '【杭州邮政】（包邮特惠）《盛世峰会·韵味杭州》纪念珍藏册', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('13', '【杭州邮政】《盛世峰会·韵味杭州》纪念珍藏册', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('14', '【杭州邮政】《盛世峰会·韵味杭州》纪念珍藏册（每人限购4册，仅邮寄）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('15', '【杭州邮政】《盛世峰会·韵味杭州》纪念珍藏册（自提）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('16', '【杭州邮政】预售（9月陆续发货）《盛世峰会·韵味杭州》纪念珍藏册(内部自提)（预订优惠）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('17', '【杭州邮政】预售（9月陆续发货）《盛世峰会·韵味杭州》纪念珍藏册（预订优惠）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('18', '【杭州邮政】“恭贺新禧”定时递贺卡', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('19', '【杭州邮政】“恭贺新禧”定时递明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('20', '【杭州邮政】“江南忆”G20国礼套装（仅自提）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('21', '【杭州邮政】“祈福颂彩”生肖贺岁礼盒', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('22', '【杭州邮政】“盛世中国”生肖贺岁礼盒（仅自提）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('23', '【杭州邮政】“丝香门第”蚕丝面膜套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('24', '【杭州邮政】《 美哉·杭州 》杭州风光摄影明信片集', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('25', '【杭州邮政】《蝙蝠侠》 珍藏明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('26', '【杭州邮政】《超人》珍藏明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('27', '【杭州邮政】《辞旧迎新》首轮生肖交替邮资封片珍藏折', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('28', '【杭州邮政】《大白熊》明信片套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('29', '【杭州邮政】《福猴满堂》丙申猴票2016猴年邮资图大全套', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('30', '【杭州邮政】《福猴满堂》丙申猴票2016猴年邮资图大全套', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('31', '【杭州邮政】《韩美林百鸡图》', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('32', '【杭州邮政】《杭州夜十景》明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('33', '【杭州邮政】《杭州映像诗》明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('34', '【杭州邮政】《鸡年酉福》国画明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('35', '【杭州邮政】《寄给远方的归人》郑愁予诗歌明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('36', '【杭州邮政】《寄给远方的归人》郑愁予诗歌明信片（原价30元，特惠价20元）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('37', '【杭州邮政】《立春》邮资机宣传戳纪念封片组合', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('38', '【杭州邮政】《美丽杭州 诗意西湖》西湖十景诗歌明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('39', '【杭州邮政】《美丽中国·西溪湿地》邮票明信片珍藏折', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('40', '【杭州邮政】《美丽中国·西溪湿地》邮票明信片珍藏折（原价45元秒杀价6.6元）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('41', '【杭州邮政】《陪我到可可西里去看海》邮资明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('42', '【杭州邮政】《诗意杭州 峰会献礼》G20峰会珍藏丝巾礼盒套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('43', '【杭州邮政】《伟大的胜利》大阅兵纪念限量邮资明信片册＋纪念邮票珍藏套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('44', '【杭州邮政】《游戏规则》明信片观影兑换券', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('45', '【杭州邮政】《中国人民解放军建军九十周年纪念明信片》', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('46', '【杭州邮政】《最忆是杭州》集戳本', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('47', '【杭州邮政】2016超级旅游护照个人版', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('48', '【杭州邮政】2016超级旅游护照个人版（原价95元秒杀价6.6元）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('49', '【杭州邮政】2016超级旅游护照个人版（原价95元秒杀价9.9元）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('50', '【杭州邮政】2017超级旅游护照个人版', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('51', '【杭州邮政】2017超级旅游护照家庭版', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('52', '【杭州邮政】G20二十国花卉明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('53', '【杭州邮政】G20纪念丝绸团扇套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('54', '【杭州邮政】G20纪念丝绸折扇套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('55', '【杭州邮政】百猴图明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('56', '【杭州邮政】超值电影票（原价38元秒杀价1元）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('57', '【杭州邮政】电影通兑票', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('58', '【杭州邮政】丁酉年贺年国版信卡', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('59', '【杭州邮政】丁酉年生肖国版“金鸡报春”明信片套装 （前200名送福字一对）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('60', '【杭州邮政】丁酉年生肖红包套装（含生肖鸡票）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('61', '【杭州邮政】东南佛国2017年祈福台历', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('62', '【杭州邮政】二十四节气明信片册', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('63', '【杭州邮政】杭州超值电影票（原价38元秒杀价6.6元）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('64', '【杭州邮政】杭州旅游护照G20线路优惠联票（每个ID限3本）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('65', '【杭州邮政】杭州特色丝绸团扇', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('66', '【杭州邮政】杭州韵味古风折扇', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('67', '【杭州邮政】浪漫的约会（让·皮埃尔的西湖十景）明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('68', '【杭州邮政】刘海栗国画邮资明信片册', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('69', '【杭州邮政】刘海粟油画邮资明信片册', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('70', '【杭州邮政】流光溢彩二十国G20峰会风景明信片（风景版）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('71', '【杭州邮政】流光溢彩二十国G20峰会风情明信片（建筑版）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('72', '【杭州邮政】六六大吉-2017贺年有奖封片套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('73', '【杭州邮政】生肖猴封片大全套', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('74', '【杭州邮政】生肖猴封片大全套（原价50元秒杀价1元）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('75', '【杭州邮政】盛世繁花G20峰会真丝明信片丝巾套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('76', '【杭州邮政】盛世繁花G20峰会真丝明信片丝巾套装（邮政日特惠，限量100套，买就送精美西湖手包）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('77', '【杭州邮政】盛世繁花G20峰会真丝明信片丝巾套装（自提）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('78', '【杭州邮政】十二生肖涂鸦手绘无邮资明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('79', '【杭州邮政】四大名著之《红楼梦》明信片套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('80', '【杭州邮政】四大名著之《三国演义》明信片套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('81', '【杭州邮政】四大名著之《水浒传》明信片套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('82', '【杭州邮政】四大名著之《西游记》明信片套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('83', '【杭州邮政】吴冠中四季系列套装（含明信片、笔记本）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('84', '【杭州邮政】现货-浙江大学120周年校庆纪念明信片邮票套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('85', '【杭州邮政】预售《猴年马月》贺卡明信片，含贺卡封', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('86', '【杭州邮政】预售《美丽杭州 诗意西湖》西湖十景诗歌明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('87', '【杭州邮政】预售-《中国人民解放军建军九十周年纪念银章（27g）》套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('88', '【杭州邮政】预售-《中国人民解放军建军九十周年纪念银章（90g）》套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('89', '【杭州邮政】预售2017乐邮香港旅游护照（香港回归20周年倾情回馈）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('90', '【杭州邮政】预售-超级旅游爆款新品', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('91', '【杭州邮政】预售-浙江大学120周年校庆纪念珍藏明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('92', '【杭州邮政】运河风情手绘明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('93', '【杭州邮政】浙大120周年校庆《思想等式》智慧明信片邮品套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('94', 'G20纪念版邮资封、明信片', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('95', '鸡票首发特惠《十二生肖之鸡年酉福》贺岁套装（原价30元，6日0点下架）', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('96', '精选品牌蚕丝夏被，送爱的人一个舒适的睡眠', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('97', '送长辈24K金箔康乃馨＋主题明信片套装', '1', '0', null, null, '0');
INSERT INTO `in_stock` VALUES ('103', '11', '11', '11', '11', '11', '0');
INSERT INTO `in_stock` VALUES ('104', '【杭州邮政】《美丽杭州 诗意西湖》西湖十景诗歌明信片', '10', '30', '20', '测试', '0');
INSERT INTO `in_stock` VALUES ('105', '【杭州邮政】预售《美丽杭州 诗意西湖》西湖十景诗歌明信片', '10', '30', '20', '测试', '0');
INSERT INTO `in_stock` VALUES ('106', '西湖123', '10', '30', '20', '册似乎', '0');
INSERT INTO `in_stock` VALUES ('107', '111', '1', '1', '11', '1', '0');
INSERT INTO `in_stock` VALUES ('108', '222', '2', '2', '2', '2', '0');
INSERT INTO `in_stock` VALUES ('109', '测试数据', '10', '30', '20', '测试位置', '0');
INSERT INTO `in_stock` VALUES ('110', '123123', '123', '123', '123', '123', '0');

-- ----------------------------
-- Table structure for `outload`
-- ----------------------------
DROP TABLE IF EXISTS `outload`;
CREATE TABLE `outload` (
  `RC` int(10) NOT NULL AUTO_INCREMENT,
  `In_stock_ID` int(10) DEFAULT NULL,
  `In_stock_Name` varchar(80) DEFAULT NULL,
  `Unit_ID` int(10) DEFAULT NULL,
  `Unit_Name` varchar(80) DEFAULT NULL,
  `Amount` decimal(10,0) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `Flag` int(1) DEFAULT NULL,
  PRIMARY KEY (`RC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of outload
-- ----------------------------

-- ----------------------------
-- Table structure for `unit`
-- ----------------------------
DROP TABLE IF EXISTS `unit`;
CREATE TABLE `unit` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(80) DEFAULT NULL,
  `RC` int(10) DEFAULT NULL,
  `Flag` int(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of unit
-- ----------------------------
INSERT INTO `unit` VALUES ('1', '沈骅', '0', '0');
INSERT INTO `unit` VALUES ('2', '陈立顺', '0', '0');
INSERT INTO `unit` VALUES ('6', '邮政', '0', '0');
INSERT INTO `unit` VALUES ('7', '广州', '0', '0');
INSERT INTO `unit` VALUES ('8', '杭州', '0', '0');
INSERT INTO `unit` VALUES ('9', '南京', '0', '0');
INSERT INTO `unit` VALUES ('10', '沈阳', '0', '0');

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `User` varchar(40) DEFAULT NULL,
  `Password` varchar(40) DEFAULT NULL,
  `Flag` int(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user
-- ----------------------------
