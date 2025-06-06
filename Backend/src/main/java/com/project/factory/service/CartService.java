package com.project.factory.service;


import com.project.factory.model.Cart;
import com.project.factory.repository.CartRepository;
import com.project.factory.repository.ProductRepository;
import com.project.factory.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDateTime;
import java.util.List;

@Service
public class CartService
{
    @Autowired
    private CartRepository cartRepository;

    @Autowired
    private ProductRepository productRepository;

    @Autowired
    private UserRepository userRepository;

    @Transactional
    public int addCart(int productId, int quantity, String email)
    {
        if (productId <= 0)
        {
            throw new IllegalArgumentException("Invalid product ID");
        }

        if (quantity <= 0)
        {
            throw new IllegalArgumentException("Quantity must be greater than 0");
        }

        if (email == null || email.isEmpty())
        {
            throw new IllegalArgumentException("Email cannot be empty");
        }

        int userId = userRepository.findUserIdByEmail(email);

        Cart existingCart = cartRepository.findActiveCartByUserIdAndProductId(userId, productId);

        if (existingCart != null)
        {
            int newQuantity = existingCart.getQuantity() + quantity;
            productRepository.updateStock(quantity, productId);
            return cartRepository.updateCart(existingCart.getId(), newQuantity, userId);
        }
        else
        {
            productRepository.updateStock(quantity, productId);
            LocalDateTime createdAt = LocalDateTime.now();
            return cartRepository.createCart(quantity, createdAt, productId, userId);
        }
    }


    public List<Cart> getAllCartsByUserName(String username)
    {
        if (username == null || username.isEmpty())
        {
            throw new IllegalArgumentException("Username cannot be empty");
        }

        int userId = userRepository.findUserIdByEmail(username);

        if (userId <= 0)
        {
            throw new IllegalArgumentException("Invalid user ID");
        }
       return cartRepository.findAllByUserId(userId);
    }

    @Transactional
    public int updateCart(int cartId, int quantity, String username)
    {
        Cart cart = cartRepository.findById(cartId)
                .orElseThrow(() -> new IllegalArgumentException("Cart not found"));

        if (cartId <= 0)
        {
            throw new IllegalArgumentException("Invalid cart ID");
        }

        if (quantity <= 0)
        {
            throw new IllegalArgumentException("Quantity must be greater than 0");
        }

        if (username == null || username.isEmpty())
        {
            throw new IllegalArgumentException("Username cannot be empty");
        }

        productRepository.updateStock(quantity - cart.getQuantity(), cart.getProduct().getId());

        int id = userRepository.findUserIdByEmail(username);

        return cartRepository.updateCart(cartId, quantity, id);
    }


    @Transactional
    public void deleteCart(int cartId)
    {
        Cart cart = cartRepository.findById(cartId)
                .orElseThrow(() -> new IllegalArgumentException("Cart not found"));

        if (cart == null)
        {
            throw new IllegalArgumentException("Cart not found");
        }

        int quantity = -cart.getQuantity();

        int productId = cart.getProduct().getId();

        productRepository.updateStock(quantity, productId);

        cartRepository.deleteById(cartId);
    }
}
