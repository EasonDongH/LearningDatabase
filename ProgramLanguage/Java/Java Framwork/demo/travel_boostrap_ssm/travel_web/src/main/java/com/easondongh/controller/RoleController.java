package com.easondongh.controller;

import com.easondongh.domain.Permission;
import com.easondongh.domain.Role;
import com.easondongh.service.RoleService;
import com.easondongh.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

import java.util.List;

@Controller
@RequestMapping("/role")
public class RoleController {

    @Autowired
    private RoleService roleService;
    @Autowired
    private UserService userService;

    @RequestMapping("/findAll.do")
    public ModelAndView findAll(){
        ModelAndView mv = new ModelAndView();
        List<Role> roleList = this.roleService.findAll();
        mv.addObject("roleList", roleList);
        mv.setViewName("role-list");
        return mv;
    }

    @RequestMapping("/save.do")
    public String save(@RequestParam(name = "roleName", required = true) String roleName,@RequestParam(name = "roleDesc", required = true) String roleDesc){
        this.roleService.save(roleName,roleDesc);
        return "redirect:findAll.do";
    }

    @RequestMapping("/findRoleByIdAndAllPermission.do")
    public ModelAndView findRoleByIdAndAllPermission(@RequestParam(name = "id", required = true) String roleId){
        ModelAndView mv = new ModelAndView();
        Role role = this.roleService.findById(roleId);
        List<Permission> permissionList = this.roleService.findOtherPermissions(roleId);
        mv.addObject("role", role);
        mv.addObject("permissionList", permissionList);
        mv.setViewName("role-permission-add");
        return mv;
    }

    @RequestMapping("/addPermissionsToRole.do")
    public String addPermissionsToRole(String roleId, String[] ids){
        this.roleService.addPermissionsToRole(roleId, ids);
        return "redirect:findAll.do";
    }
}
