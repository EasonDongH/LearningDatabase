package com.easondongh.domain;

import java.io.Serializable;
import java.util.List;
import java.util.Map;

public class Account implements Serializable {
    private String name;
    private double money;
    private User user;
    private List<User> list;
    private Map<String,User> map;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getMoney() {
        return money;
    }

    public void setMoney(double money) {
        this.money = money;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public List<User> getList() {
        return list;
    }

    public void setList(List<User> list) {
        this.list = list;
    }

    public Map<String, User> getMap() {
        return map;
    }

    public void setMap(Map<String, User> map) {
        this.map = map;
    }

    @Override
    public String toString() {
        return "Account{" +
                "name='" + name + '\'' +
                ", money=" + money +
                ", user=" + user +
                ", list=" + list +
                ", map=" + map +
                '}';
    }
}
