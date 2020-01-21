package com.easondongh.controller;

import com.easondongh.domain.Product;
import com.easondongh.service.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

import javax.annotation.security.RolesAllowed;
import java.util.List;

@Controller
@RequestMapping("/product")
public class ProductController {

    @Autowired
    private ProductService productService;

    @RequestMapping("/findAll.do")
    @RolesAllowed("ADMIN")
    public ModelAndView findAll(){
        ModelAndView mv = new ModelAndView();
        List<Product> list = this.productService.findAll();
        mv.addObject("productList", list);
        mv.setViewName("product-list");
        return mv;
    }

    @RequestMapping("/save.do")
    public String save(Product product) {
        this.productService.save(product);
        return "redirect:findAll.do";
    }
}
