; 3. Dla tekstu wprowadzonego z klawiatury, wypisać pojedynczo wszystkie jego znaki.

section .txt
	org 100H

start:
    mov ah, 0ah                 ; DOS function that reads a line of input from the user.
    mov dx, input               ; Loads the address of input into DX
    int 21h
    

    mov si, input + 2           ; We add 2 because the first byte is maximum input length and the second byte is count of characters entered

    mov ah,9
	mov dx, doubleNewLine
	int 21h

start_loop:

    mov al, [si]                ; Load the character from the si adress 
    cmp al, '$'                 ; Compare character with $
    je end                      ; If al is $, jump to end

    mov ah, 2                   ; Set up DOS function 2 (print character in DL)
    mov dl, al                  ; Load the character from the string
    int 21h

    mov ah,9
	mov dx, newline
	int 21h

    inc si                     ;  Increment si
    jmp start_loop

end:
    mov ax, 4C00h
    int 21h

section .data
    doubleNewLine db 10,13,10,13,36
    newline db 10,13,36         ; Define the newline in memory
	input db 20                 ; Input buffer size
          db 0                  ; Number of characters entered
          times 20 db "$"       ; Input characters buffer
