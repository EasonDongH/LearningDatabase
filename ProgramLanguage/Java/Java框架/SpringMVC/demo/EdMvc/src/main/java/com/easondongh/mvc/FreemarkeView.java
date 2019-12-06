package com.easondongh.mvc;

import java.util.HashMap;
import java.util.Map;

/**
 *  视图对象
 */
public class FreemarkeView {

    private String ftlPath;
    private Map<String,Object> models = new HashMap<>();

    public FreemarkeView(String ftlPath) {
        this.ftlPath = ftlPath;
    }

    public FreemarkeView(String ftlPath, Map<String, Object> models) {
        this.ftlPath = ftlPath;
        this.models = models;
    }

    public String getFtlPath() {
        return ftlPath;
    }

    public void setFtlPath(String ftlPath) {
        this.ftlPath = ftlPath;
    }

    public Map<String, Object> getModels() {
        return models;
    }

    public void setModels(Map<String, Object> models) {
        this.models = models;
    }
}
