; 1. Dla zadanej zmiennej 3 cyfrowej, 8-mio bitowej, wypisać ją na ekran (jako liczbę), bez użycia pętli
section .text
    org 100h

start:
    mov al, 215             ; Load the value 123 into AL register
    
    
    xor ah, ah          
    mov bl, 100             ; Load 100 into BL register for division
    div bl                  ; Divide AX by BL (100); result in AL = quotient, AH = remainder
                        
    add al, '0'             ; Convert Al to ASCII
    mov dl, al              ; Store ASCII character (quotient) in DL for display
    mov dh, ah              ; Store remainder (in AH) in DH for further processing
    mov ah, 2           
    int 21h             

 
    mov al, dh              ; Move remainder (stored in DH) back to AL
    xor ah, ah          
    mov bl, 10          
    div bl                  ; Divide AX by BL (10); result in AL = quotient, AH = remainder

    add al, '0'             ; Convert Al to ASCII
    mov dl, al              ; Move ASCII character (quotient) to DL for display
    mov dh, ah              ; Move remainder (in AH) to DH for further processing
    mov ah, 2           
    int 21h             


    mov al, dh              ; Move remainder (stored in DH) back to AL 
    add al, '0'             ; Convert Al to ASCII
    mov dl, al              ; Move ASCII character (quotient) to DL for display
    mov ah, 2           
    int 21h             

    ; Exit the program
    mov ah, 4Ch         
    int 21h             
