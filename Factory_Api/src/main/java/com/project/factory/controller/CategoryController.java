package com.project.factory.controller;


import com.project.factory.service.CategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/category")
public class CategoryController
{

    @Autowired
    private CategoryService categoryService;

    @GetMapping()
    public ResponseEntity<?> getCategory()
    {
        return ResponseEntity.ok(categoryService.getCategory());
    }



}
