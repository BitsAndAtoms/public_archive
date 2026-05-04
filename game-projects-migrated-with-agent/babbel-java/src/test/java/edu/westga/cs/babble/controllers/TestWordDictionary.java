package edu.westga.cs.babble.controllers;

import static org.junit.Assert.assertFalse;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.assertTrue;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import edu.westga.cs.babble.controllers.WordDictionary;

/**
 * Test for word dictionary
 * 
 * @author Siddhartha Gupta
 * @version 8/31/2018
 *
 */
public class TestWordDictionary {

	WordDictionary dictionary;

	/**
	 * sets up the dictionary instance variable
	 * 
	 * @throws Exception
	 *             if dictionary is not found
	 */
	@BeforeEach
	public void setUp() throws Exception {
		this.dictionary = new WordDictionary();
	}

	/**
	 * test to check valid string expand
	 */
	@Test
	public void stringExpandShouldBeValid() {
		assertTrue(this.dictionary.isValidWord("Expand"));
	}

	/**
	 * test to check invalid string
	 */
	@Test
	public void stringBugblatShouldNotBeValid() {
		assertFalse(this.dictionary.isValidWord("Bugblat"));
	}

	/**
	 * test to check empty string is not valid
	 */
	@Test
	public void emptyStringShouldNotBeValid() {
		assertFalse(this.dictionary.isValidWord(""));
	}

	/**
	 * test to check null is not valid
	 */
	@Test
	public void shouldNotAcceptNull() {
		assertThrows(IllegalArgumentException.class, () -> {
			this.dictionary.isValidWord(null);
		});
	}
}
